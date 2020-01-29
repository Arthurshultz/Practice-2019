using Model.GameObjects;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace View
{
    public partial class ViewReport : Form
    {
        public IEnumerable<GameObject> GOList;

        public ViewReport()
        {
            InitializeComponent();
        }

        private void timerViewReport_Tick(object sender, EventArgs e)
        {
            DGVReport.Rows.Clear();

            foreach (var o in GOList)
            {
                DGVReport.Rows.Add(o, o.PosX.ToString(), o.PosY.ToString());
            }
        }

        private void ViewReport_Load(object sender, EventArgs e)
        {
            DGVReport.ColumnCount = 3;
            DGVReport.ColumnHeadersVisible = true;
            DGVReport.Columns[0].Name = "Name";
            DGVReport.Columns[1].Name = "Position X";
            DGVReport.Columns[2].Name = "Position Y";
        }
    }
}
