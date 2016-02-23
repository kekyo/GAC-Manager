using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GAC_Manager.Properties;

namespace GAC_Manager
{
    public partial class FilterForm : Form
    {
        static Settings settings = new Settings();

        private static List<string> filters = new List<string>();
        public static IEnumerable<string> Filters
        {
            get { return FilterForm.filters; }
        }

        static FilterForm()
        {
            string[] lines = settings.Filters.Split('\n');
            foreach (var line in lines)
                FilterForm.filters.Add(line.Trim());
        }

        public FilterForm()
        {
            InitializeComponent();

            this.filterTextBox.Text = settings.Filters;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            FilterForm.filters.Clear();
            string[] lines = this.filterTextBox.Text.Split('\n');
            foreach (var line in lines)
                FilterForm.filters.Add(line.Trim());

            settings.Filters = this.filterTextBox.Text;
            settings.Save();

            this.Close();
            this.Dispose();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        public static void ClearFilters()
        {
            FilterForm.filters.Clear();
        }

        public static bool MatchesFilter(string s)
        {
            if (FilterForm.filters.Count == 0)
                return true;

            foreach (var filter in FilterForm.filters)
                if (s.Contains(filter))
                    return true;
            return false;
        }
    }
}
