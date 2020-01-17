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

        public Direction Direction { get; set; }

        // далее костыли для теста
        int Width = 640;
        int Height = 640;

        Random rnd = new Random();

        public GameModel()
        {
            _gameObjects.Add(new KolobokView(300, 300, 48, 48, Sprites.Kolobok_Right));
            _gameObjects.Add(new TankView(300, 200, 48, 48, Sprites.Tank_Down));
        }

        public void NewGame()
        {
            //_gameObjects.Add(new KolobokView(10, 10, 48, 48, Sprites.Kolobok_Right));
        }

        public void Update()
        {
            KolobokView kolob = _gameObjects.OfType<KolobokView>().First();
            TankView tank = _gameObjects.OfType<TankView>().First();

            //--//--// test screen offset
            if (InScreen(kolob))
            {
                if (Direction != Direction.None)
                    kolob.currentDirection = Direction;
            }
            else
            {
                Direction = Direction.None;
                kolob.PushOff();
            }

            //--//--// test Collision
            if (ObjectCollision(kolob,tank))
            {
                Direction = Direction.None;
                kolob.PushOff();
                tank.TurnAround();
            }

            //--//--// test tank movement
            if (!InScreen(tank))
            {
                tank.PushOff();
                tank.TurnAround();
            }

            if (rnd.Next(1000) < 10)
            {
                tank.ChangeDirection();
            }



            tank.Move();
            tank.Draw();
            kolob.Move();
            kolob.Draw();
        }

        private bool InScreen(MovingObject obj)
        {
            return (obj.Position.X > 0)&&
                (obj.Position.X < Width - obj.Width)&&
                (obj.Position.Y > 0)&&
                (obj.Position.Y < Height - obj.Height);
        }

        private bool ObjectCollision(GameObject obj1, GameObject obj2)
        {
            return (obj1.Position.X + obj1.Width > obj2.Position.X) &&
                (obj1.Position.X <= obj2.Position.X + obj2.Width) &&
                (obj1.Position.Y + obj1.Height > obj2.Position.Y) &&
                (obj1.Position.Y <= obj2.Position.Y + obj2.Height);
        }
    }
}
