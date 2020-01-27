using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Controller;
using Model;
using Model.GameObjects;
using Model.ViewObjects;

namespace View
{
    public partial class ViewForm : Form
    {
        IController _controller;
        static IModelView _modelView;

        ViewReport viewReport;
        bool isOpen = false;

        int _formOffsetWidth = 40;
        int _formOffsetHeight = 90;

        public ViewForm(IController controller,IModelView modelView)
        {
            _controller = controller;
            _modelView = modelView;

            InitializeComponent();
        }

        public ViewForm(IController controller, IModelView modelView, int fieldWidth, int fieldHeight)
        {
            _controller = controller;
            _modelView = modelView;

            InitializeComponent();

            this.Width = fieldWidth + _formOffsetWidth;
            this.Height = fieldHeight + _formOffsetHeight;
            picBoxField.Width = fieldWidth;
            picBoxField.Height = fieldWidth;
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

            // если реже обновлять, то тормозов меньше
            //if (viewReport != null)
            //    viewReport.DGVReport.Refresh();
 
            if (viewReport != null)
                DgvUpdateManually();
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

                // v1 все элементы
                //viewReport.DGVReport.DataSource = _modelView.GameObjects;

                // v2
                // см. DgvUpdateManually()

                // v3.1 исключая стены
                //viewReport.DGVReport.DataSource = _modelView.GameObjects.Where(t => !(t is BrickWallView)).ToList();

                /* v3.2 на биндинг листе, но он не обновляется автоматически, приходится рефрешить.
                  возможно поможет реализация INotifyPropertyChanged у GameObject */
                //viewReport.DGVReport.DataSource = new BindingList<GameObject>(
                //    _modelView.GameObjects.Where(t => !(t is BrickWallView)).ToList());

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

        private void DgvUpdateManually()
        {
            viewReport.DGVReport.ColumnCount = 3;
            viewReport.DGVReport.ColumnHeadersVisible = true;
            viewReport.DGVReport.Columns[0].Name = "Name";
            viewReport.DGVReport.Columns[1].Name = "Position X";
            viewReport.DGVReport.Columns[2].Name = "Position Y";

            viewReport.DGVReport.Rows.Clear();

            foreach (var o in _modelView.GameObjects.Where(t => !(t is BrickWallView)))
            {
                viewReport.DGVReport.Rows.Add(o, o.PosX.ToString(), o.PosY.ToString());
            }
        }

        private void Draw()
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
