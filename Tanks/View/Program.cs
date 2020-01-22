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
            bool isLoaded = true;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                GameModel _gameModell = new GameModel(int.Parse(arg[0]), int.Parse(arg[1]), int.Parse(arg[2]), int.Parse(arg[3]), int.Parse(arg[4]));
                IController _controllerr = new PackmanController(_gameModell);
                Application.Run(new ViewForm(_controllerr, _gameModell, int.Parse(arg[0]), int.Parse(arg[1])));
            }
            catch
            {
                isLoaded = !isLoaded;
            }
            finally
            {
                if (!isLoaded)
                {
                    GameModel _gameModel = new GameModel();
                    IController _controller = new PackmanController(_gameModel);
                    Application.Run(new ViewForm(_controller, _gameModel));
                }
            }     
        }
    }
}
