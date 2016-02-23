using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.GACManagedAccess;
using System.Reflection;
using System.Configuration;
using GAC_Manager.Properties;
using ManagedFusion;

namespace GAC_Manager
{
    public partial class MainForm : Form
    {
        Settings settings = new Settings();

        public MainForm()
        {
            InitializeComponent();

            this.UpdateAssemblyList();
        }

        private void UpdateAssemblyList()
        {
            var cursor = this.Cursor;
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

            this.gacListView.BeginUpdate();
            this.gacListView.Items.Clear();

            AssemblyCacheEnum gacEnum = new AssemblyCacheEnum(null);
            List<AssemblyName> assemblyNames = new List<AssemblyName>();


            while (true)
            {
                string name = gacEnum.GetNextAssembly();
                if (name == null)
                    break;

                AssemblyName assemblyName = new AssemblyName(name);
                assemblyNames.Add(assemblyName);
            }

            foreach (var assemblyName in assemblyNames.Where(a => FilterForm.MatchesFilter(a.Name) == true).OrderBy(a => a.Name))
            {
                ListViewItem item = new ListViewItem(new string[] {
                    assemblyName.Name,
                    assemblyName.Version.ToString(),
                    assemblyName.CultureInfo.ToString(),
                    this.ByteArrayToHex(assemblyName.GetPublicKeyToken())
                });
                item.Tag = assemblyName;

                this.gacListView.Items.Add(item);
            }

            this.gacListView.EndUpdate();
            this.Cursor = cursor;
        }

        private string ByteArrayToHex(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder(bytes.Length * 2);
            foreach (var b in bytes)
                sb.Append(b.ToString("X2").ToLower());
            return sb.ToString();
        }

        private void removeFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FilterForm.ClearFilters();
            this.UpdateAssemblyList();
        }

        private void installAssemblyButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (!string.IsNullOrEmpty(settings.InitialLibDirectory))
                ofd.InitialDirectory = settings.InitialLibDirectory;
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            ofd.AutoUpgradeEnabled = true;
            ofd.Filter = string.Format("{0} Files|*.{0}", "DLL");
            ofd.Multiselect = true;
            ofd.ShowDialog();

            foreach (var fileName in ofd.FileNames)
            {
                FileInfo fileInfo = new FileInfo(fileName);
                settings.InitialLibDirectory = fileInfo.Directory.FullName;
                settings.Save();

                this.InstallAssembly(fileName);
            }

            this.UpdateAssemblyList();
        }

        private void deleteCheckedAssembliesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            bool errors = false;

            foreach (ListViewItem item in gacListView.Items)
            {
                if (!item.Checked)
                    continue;

                try
                {
                    var ud = this.UninstallAssembly((AssemblyName)item.Tag);
                    if (ud != UninstallDisposition.None && ud != UninstallDisposition.Uninstalled)
                    {
                        sb.AppendFormat("{0}: {1}", ((AssemblyName)item.Tag).Name, ud);
                        errors = true;
                    }
                }
                catch (Exception ex)
                {
                    sb.AppendFormat("{0}: {1}", ex.Message);
                    errors = true;
                }
            }

            if (errors)
                MessageBox.Show("The following errors were encountered:\n\n" + sb.ToString());
            else
                MessageBox.Show("Selected assemblies were successfully removed from the GAC.");

            this.UpdateAssemblyList();
        }

        private void deleteCurrentlySelectedAssemblyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            bool errors = false;

            foreach (ListViewItem item in this.gacListView.SelectedItems)
            {
                try
                {
                    var ud = this.UninstallAssembly((AssemblyName)item.Tag);
                    if (ud != UninstallDisposition.None && ud != UninstallDisposition.Uninstalled)
                    {
                        sb.AppendFormat("{0}: {1}", ((AssemblyName)item.Tag).Name, ud);
                        errors = true;
                    }
                }
                catch (Exception ex)
                {
                    sb.AppendFormat("{0}: {1}", ex.Message);
                    errors = true;
                }
            }

            if (errors)
                MessageBox.Show("The following errors were encountered:\n\n" + sb.ToString());
            else
                MessageBox.Show("Selected assemblies were successfully removed from the GAC.");

            this.UpdateAssemblyList();
        }

        private void toolStripButton1_ButtonClick(object sender, EventArgs e)
        {
            FilterForm form = new FilterForm();
            form.ShowDialog();
            this.UpdateAssemblyList();
        }

        private void gacListView_MouseClick(object sender, MouseEventArgs e)
        {
            ContextMenu menu = null;
            var itemAtClick = gacListView.GetItemAt(e.X, e.Y);

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                menu = new ContextMenu();
                
                if (itemAtClick != null)
                {
                    foreach (ListViewItem item in gacListView.Items)
                        item.Selected = false;
                    itemAtClick.Selected = true;

                    menu.MenuItems.Add(new MenuItem("Remove", new EventHandler(deleteCurrentlySelectedAssemblyToolStripMenuItem_Click)));
                    menu.MenuItems.Add(new MenuItem("Replace", new EventHandler(ReplaceMenuItem_Click)));
                    menu.MenuItems.Add("-");
                }
                
                menu.MenuItems.Add("Install", new EventHandler(installAssemblyButton_Click));
            }

            gacListView.ContextMenu = menu;
            if (menu != null)
                menu.Show(gacListView, e.Location);

            gacListView.ContextMenu = new ContextMenu(new MenuItem[] { new MenuItem("Install", new EventHandler(installAssemblyButton_Click)) });
        }

        private void ReplaceMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            bool errors = false;

            List<ListViewItem> selectedItems = new List<ListViewItem>();
            foreach (ListViewItem item in gacListView.SelectedItems)
                selectedItems.Add(item);
            var selectedItem = selectedItems[0];

            OpenFileDialog ofd = new OpenFileDialog();
            if (!string.IsNullOrEmpty(settings.InitialLibDirectory))
                ofd.InitialDirectory = settings.InitialLibDirectory;
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            ofd.AutoUpgradeEnabled = true;
            ofd.Filter = string.Format("{0} Files|*.{0}", "DLL");
            ofd.Multiselect = false;
            ofd.ShowDialog();

            if (!string.IsNullOrEmpty(ofd.FileName))
            {
                AssemblyName assemblyName = AssemblyName.GetAssemblyName(ofd.FileName);
                if (assemblyName.FullName != ((AssemblyName)selectedItem.Tag).FullName)
                {
                    MessageBox.Show(string.Format("Cannot replace:\n\n- {0}\n\nwith...\n\n- {1}\n\nThey are not the same assembly.", ((AssemblyName)selectedItem.Tag).FullName, assemblyName.FullName));
                    return;
                }

                var ud = this.UninstallAssembly((AssemblyName)selectedItem.Tag);
                if (ud != UninstallDisposition.None && ud != UninstallDisposition.Uninstalled)
                {
                    sb.AppendFormat("Error removing assembly: {0}: {1}", ((AssemblyName)selectedItem.Tag).Name, ud);
                    errors = true;
                }

                FileInfo fileInfo = new FileInfo(ofd.FileName);
                settings.InitialLibDirectory = fileInfo.Directory.FullName;
                settings.Save();

                if (!errors)
                {
                    if (!this.InstallAssembly(ofd.FileName))
                    {
                        sb.AppendFormat("Error installing assembly at:\n\n{0}", ofd.FileName);
                        errors = true;
                    }
                }
            }

            if (errors)
                MessageBox.Show("The following errors were encountered:\n\n" + sb.ToString());
            else
                MessageBox.Show("Selected assemblies were successfully replaced in the GAC.");

            this.UpdateAssemblyList();
        }

        private UninstallDisposition UninstallAssembly(AssemblyName assemblyName)
        {
            InstallerDescription desc = InstallerDescription.CreateForOpaqueString("", "Paynova");
            var gac = new ManagedFusion.AssemblyCache(desc);
            UninstallDisposition ud = gac.UninstallAssembly(assemblyName);
            return ud;
        }

        private bool InstallAssembly(string filePath)
        {
            try
            {
                AssemblyName assemblyName = AssemblyName.GetAssemblyName(filePath);
                assemblyName.CodeBase = filePath;
                InstallerDescription desc = InstallerDescription.CreateForOpaqueString("", "Paynova");
                var gac = new ManagedFusion.AssemblyCache(desc);
                gac.InstallAssembly(assemblyName, InstallBehaviour.Refresh);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
