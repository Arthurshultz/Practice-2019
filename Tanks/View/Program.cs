using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controller;
using Model;

namespace View
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            GameModel _gameModel = new GameModel();
            IController _controller = new PackmanController(_gameModel);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new ViewForm(_controller,_gameModel.GameObjects));
        }
    }
}
