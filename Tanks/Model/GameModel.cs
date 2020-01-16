using Model.GameObjects;
using Model.ViewObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Model
{
    public class GameModel : IModel
    {
        private List<GameObject> _gameObjects = new List<GameObject>();
        public IEnumerable<GameObject> GameObjects { get => _gameObjects; }

        public Direction Direction { get ; set ; }


        // далее костыли для теста

        public GameModel()
        {
            _gameObjects.Add(new KolobokView(300, 300, 48, 48, Sprites.Kolobok_Right));
        }


        public void NewGame()
        {
            //_gameObjects.Add(new KolobokView(10, 10, 48, 48, Sprites.Kolobok_Right));
        }

        public void Update()
        {
            KolobokView kolob = _gameObjects.OfType<KolobokView>().First();
            kolob.Move(Direction);
            kolob.Draw(Direction);
        }
    }
}
