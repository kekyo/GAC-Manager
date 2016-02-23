namespace GAC_Manager
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.gacListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.installAssemblyButton = new System.Windows.Forms.ToolStripButton();
            this.removeAssemblyButton = new System.Windows.Forms.ToolStripSplitButton();
            this.deleteCheckedAssembliesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteCurrentlySelectedAssemblyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.removeFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(823, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.gacListView);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(823, 434);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 24);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(823, 459);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // gacListView
            // 
            this.gacListView.CheckBoxes = true;
            this.gacListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.gacListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gacListView.FullRowSelect = true;
            this.gacListView.GridLines = true;
            this.gacListView.Location = new System.Drawing.Point(0, 0);
            this.gacListView.Name = "gacListView";
            this.gacListView.Size = new System.Drawing.Size(823, 434);
            this.gacListView.TabIndex = 0;
            this.gacListView.UseCompatibleStateImageBehavior = false;
            this.gacListView.View = System.Windows.Forms.View.Details;
            this.gacListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gacListView_MouseClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Assembly";
            this.columnHeader1.Width = 400;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Version";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Culture";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Public Key Token";
            this.columnHeader4.Width = 200;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.installAssemblyButton,
            this.removeAssemblyButton,
            this.toolStripSeparator1,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(823, 25);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 0;
            // 
            // installAssemblyButton
            // 
            this.installAssemblyButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.installAssemblyButton.Image = ((System.Drawing.Image)(resources.GetObject("installAssemblyButton.Image")));
            this.installAssemblyButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.installAssemblyButton.Name = "installAssemblyButton";
            this.installAssemblyButton.Size = new System.Drawing.Size(23, 22);
            this.installAssemblyButton.Text = "Install Assembly";
            this.installAssemblyButton.Click += new System.EventHandler(this.installAssemblyButton_Click);
            // 
            // removeAssemblyButton
            // 
            this.removeAssemblyButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.removeAssemblyButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteCheckedAssembliesToolStripMenuItem,
            this.deleteCurrentlySelectedAssemblyToolStripMenuItem});
            this.removeAssemblyButton.Image = ((System.Drawing.Image)(resources.GetObject("removeAssemblyButton.Image")));
            this.removeAssemblyButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.removeAssemblyButton.Name = "removeAssemblyButton";
            this.removeAssemblyButton.Size = new System.Drawing.Size(32, 22);
            this.removeAssemblyButton.Text = "Remove Assembly";
            // 
            // deleteCheckedAssembliesToolStripMenuItem
            // 
            this.deleteCheckedAssembliesToolStripMenuItem.Name = "deleteCheckedAssembliesToolStripMenuItem";
            this.deleteCheckedAssembliesToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.deleteCheckedAssembliesToolStripMenuItem.Text = "Delete Checked Assemblies";
            this.deleteCheckedAssembliesToolStripMenuItem.Click += new System.EventHandler(this.deleteCheckedAssembliesToolStripMenuItem_Click);
            // 
            // deleteCurrentlySelectedAssemblyToolStripMenuItem
            // 
            this.deleteCurrentlySelectedAssemblyToolStripMenuItem.Name = "deleteCurrentlySelectedAssemblyToolStripMenuItem";
            this.deleteCurrentlySelectedAssemblyToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.deleteCurrentlySelectedAssemblyToolStripMenuItem.Text = "Delete Currently Selected Assemblies";
            this.deleteCurrentlySelectedAssemblyToolStripMenuItem.Click += new System.EventHandler(this.deleteCurrentlySelectedAssemblyToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeFilterToolStripMenuItem});
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(32, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.ButtonClick += new System.EventHandler(this.toolStripButton1_ButtonClick);
            // 
            // removeFilterToolStripMenuItem
            // 
            this.removeFilterToolStripMenuItem.Name = "removeFilterToolStripMenuItem";
            this.removeFilterToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.removeFilterToolStripMenuItem.Text = "Clear Filters";
            this.removeFilterToolStripMenuItem.Click += new System.EventHandler(this.removeFilterToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 483);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "GAC Manager";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ListView gacListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton installAssemblyButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSplitButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem removeFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripSplitButton removeAssemblyButton;
        private System.Windows.Forms.ToolStripMenuItem deleteCheckedAssembliesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteCurrentlySelectedAssemblyToolStripMenuItem;

    }
}

