using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controller;
using Model;
using Model.GameObjects;

namespace View
{
    public partial class ViewForm : Form
    {
        IController _controller;
        static IModelView _modelView;

        ViewReport viewReport;
        bool isOpen = false;

        public ViewForm(IController controller,IModelView modelView)
        {
            _controller = controller;
            _modelView = modelView;

            InitializeComponent();
        }

        private void ViewForm_KeyDown(object sender, KeyEventArgs e)
        {
            _controller.KeyDown(e.KeyCode);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            ScoreAmount.Text = $"SCORE: {_modelView.Score.ToString()}";
            BtnStart.Text = _modelView.GameOver ? "Start" : "Resstart";

            _controller.Update();
            Draw();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            _controller.NewGame();
            ActiveControl = null;
        }

        private void BtnReport_Click(object sender, EventArgs e)
        {
            if (!isOpen)
            {
                viewReport = new ViewReport();
                viewReport.DGVReport.DataSource = _modelView.GameObjects;
                viewReport.Show();
                isOpen = !isOpen;
            }
            else
            {
                viewReport.Close();
                isOpen = !isOpen;
            }

            this.Activate();
            ActiveControl = null;
        }

        public void Draw()
        {
            Bitmap bm = new Bitmap(picBoxField.Width, picBoxField.Height);
            Graphics g = Graphics.FromImage(bm);

            // Draw background
            g.Clear(Color.Black);

            g.DrawString("W:A:S:D", new Font(FontFamily.GenericSerif, 18, FontStyle.Bold),
                                new SolidBrush(Color.LightGray), new PointF(0, 0));

            // Draw everything
            foreach (var go in _modelView.GameObjects)
            {
                if (go != null)
                g.DrawImage(go.Draw(), go.Position.X, go.Position.Y, go.SpriteWidth, go.SpriteHeight);
            }

            if (_modelView.GameOver)
            {
                g.DrawString("GAME OVER", new Font(FontFamily.GenericSerif, 70, FontStyle.Bold),
                                new SolidBrush(Color.LightGray), new PointF(0, 250));
            }

            picBoxField.Image = bm;
        }

    }
}
