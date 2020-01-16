using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controller;
using Model.GameObjects;

namespace View
{
    public partial class ViewForm : Form
    {
        IController _controller;
        IEnumerable<GameObject> _gameObjects;

        public ViewForm(IController controller,IEnumerable<GameObject> gameObjects)
        {
            _controller = controller;
            _gameObjects = gameObjects;

            InitializeComponent();

            
        }

        private void ViewForm_KeyDown(object sender, KeyEventArgs e)
        {
            _controller.KeyDown(e.KeyCode);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            _controller.Update();
            Draw();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            _controller.NewGame();
            BtnStart.Text = "Resstart";
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
            foreach (var go in _gameObjects)
            {
                g.DrawImage(go.Draw(), go.Position.X, go.Position.Y, go.Width, go.Height);
            }

            picBoxField.Image = bm;
        }

    }
}
