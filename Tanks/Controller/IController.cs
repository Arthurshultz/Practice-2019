using System.Windows.Forms;

namespace Controller
{
    public interface IController
    {
        void NewGame();
        void Update();
        void KeyDown(Keys key);
    }
}
