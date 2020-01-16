using Model.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
