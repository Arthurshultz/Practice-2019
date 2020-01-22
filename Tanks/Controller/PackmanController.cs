using Model;
using System.Windows.Forms;

namespace Controller
{
    public class PackmanController : IController
    {
        IModel _model;

        public PackmanController(IModel model)
        {
            _model = model;
        }

        public void NewGame()
        {
            _model.NewGame();
        }

        public void Update()
        {
            _model.Update();
        }

        public void KeyDown(Keys key)
        {
            // fix arrows

            switch (key)
            {
                case Keys.A:
                case Keys.Left:
                    _model.Direction = Direction.Left;
                    break;
                case Keys.W:
                case Keys.Up:
                    _model.Direction = Direction.Up;
                    break;
                case Keys.D:
                case Keys.Right:
                    _model.Direction = Direction.Right;
                    break;
                case Keys.S:
                case Keys.Down:
                    _model.Direction = Direction.Down;
                    break;
                case Keys.Space:
                    _model.KolobokShoot();
                    break;
            }
        }
    }
}
