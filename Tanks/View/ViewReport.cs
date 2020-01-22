using System;
using System.Windows.Forms;

namespace View
{
    public partial class ViewReport : Form
    {
        public ViewReport()
        {
            InitializeComponent();
        }

        private void timerViewReport_Tick(object sender, EventArgs e)
        {
            DGVReport.Refresh();
        }
    }
}
