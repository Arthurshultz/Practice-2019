using Model.GameObjects;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace View
{
    public partial class ViewReport : Form
    {
        public BindingList<GameObject> GOList;

        public ViewReport()
        {
            InitializeComponent();
        }

        private void timerViewReport_Tick(object sender, EventArgs e)
        {
            DGVReport.DataSource = GOList;
        }

        private void ViewReport_Load(object sender, EventArgs e)
        {
            DGVReport.ColumnCount = 3;
            DGVReport.ColumnHeadersVisible = true;
            DGVReport.Columns[0].Name = "Name";
            DGVReport.Columns[0].DataPropertyName = "Name";
            DGVReport.Columns[1].Name = "Position X";
            DGVReport.Columns[1].DataPropertyName = "PosX";
            DGVReport.Columns[2].Name = "Position Y";
            DGVReport.Columns[2].DataPropertyName = "PosY";
        }
    }
}
