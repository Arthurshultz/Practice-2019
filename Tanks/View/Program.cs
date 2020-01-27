using System;
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
        static void Main(string[] arg)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // default
            GameModel _gameModel = new GameModel();
            IController _controller = new PackmanController(_gameModel); 
            ViewForm _viewForm = new ViewForm(_controller, _gameModel);

            if (arg.Length == 5)
            {
                try
                {
                    _gameModel = new GameModel(int.Parse(arg[0]), int.Parse(arg[1]), int.Parse(arg[2]), int.Parse(arg[3]), int.Parse(arg[4]));
                    _controller = new PackmanController(_gameModel);
                    _viewForm = new ViewForm(_controller, _gameModel, int.Parse(arg[0]), int.Parse(arg[1]));
                }
                catch
                {
                    // doing something
                }
            }

            Application.Run(_viewForm);
        }
    }
}
