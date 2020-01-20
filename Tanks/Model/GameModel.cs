using Model.GameObjects;
using Model.ViewObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Model
{
    public class GameModel : IModel
    {
        private List<GameObject> _gameObjects = new List<GameObject>();
        public IEnumerable<GameObject> GameObjects { get => _gameObjects; }

        private int _score;
        public int Score { get => _score; }

        private KolobokView _kolobok; 

        public Direction Direction { get; set; }

        // default game settigns
        private int _mapWidth = 640;
        private int _mapHeight = 640;

        private int _tanksCount = 5;
        private int _appleCount = 5;

        const int _WallSize = 56;
        const int _GOSize = 40;

        bool _gameOver = true;

        Random rnd = new Random();

        public GameModel()
        {
            LoadLevel();
        }

        public void NewGame()
        {
            _gameOver = !_gameOver;
        }

        public void Update()
        {
            if (!_gameOver)
            {
                MoveTanks();
                MoveKolobok();

                BulletControl();
                PopulationControl();
            }
        }

        private bool InScreen(MovingObject obj)
        {
            return (obj.Position.X > 0)&&
                (obj.Position.X < _mapWidth - obj.SpriteWidth)&&
                (obj.Position.Y > 0)&&
                (obj.Position.Y < _mapHeight - obj.SpriteHeight);
        }

        private bool ObjectCollision(GameObject obj1, GameObject obj2)
        {
            return (obj1.Position.X + obj1.SpriteWidth > obj2.Position.X) &&
                (obj1.Position.X <= obj2.Position.X + obj2.SpriteWidth) &&
                (obj1.Position.Y + obj1.SpriteHeight > obj2.Position.Y) &&
                (obj1.Position.Y <= obj2.Position.Y + obj2.SpriteHeight);
        }

        private void MoveKolobok()
        {
            if (InScreen(_kolobok))
            {
                if (Direction != Direction.None)
                    _kolobok.CurrentDirection = Direction;
            }
            else
            {
                Direction = Direction.None;
                _kolobok.PushOff();
            }

            foreach (var v in _gameObjects.OfType<BrickWallView>().ToArray())
            {
                if (ObjectCollision(_kolobok, v))
                {
                    Direction = Direction.None;
                    _kolobok.PushOff();
                }
            }

            foreach (var t in _gameObjects.OfType<TankView>().ToArray())
            {
                if (ObjectCollision(_kolobok, t))
                {
                   
                    // GameOver ???
                    //_gameOver = !_gameOver;
                }
            }

            foreach (var a in _gameObjects.OfType<AppleView>().ToArray())
            {
                if (ObjectCollision(_kolobok, a))
                {
                    _gameObjects.Remove(a);
                    _score++;
                }
            }

            _kolobok.Move();
            _kolobok.Draw();
        }

        private void MoveTanks()
        {
            foreach (var t in _gameObjects.OfType<TankView>().ToArray())
            {
                if (rnd.Next(1000) < 10)
                {
                    t.ChangeDirection();
                }

                if (rnd.Next(3000) < 10)
                {
                    _gameObjects.Add(t.Shoot());
                }

                if (!InScreen(t))
                {
                    t.PushOff();
                    t.ChangeDirection();
                }

                foreach (var t2 in _gameObjects.OfType<TankView>().ToArray())
                {
                    if (ObjectCollision(t, t2) && t != t2)
                    {
                        t.TurnAround();
                        t2.TurnAround();
                    }
                }

                foreach (var w in _gameObjects.OfType<BrickWallView>().ToArray())
                {
                    if (ObjectCollision(t, w))
                    {
                        t.PushOff();
                        t.ChangeDirection();
                    }
                }

                t.Move();
                t.Draw();
            }
        }

        private void BulletControl()
        {
            foreach (var tb in _gameObjects.OfType<TankBulletView>().ToArray())
            {
                foreach (var w in _gameObjects.OfType<BrickWallView>().ToArray())
                {
                    if (ObjectCollision(tb, w) || !InScreen(tb))
                    {
                        _gameObjects.Remove(tb);
                    }
                }
                tb.Move();
                tb.Draw();
            }

            foreach (var kb in _gameObjects.OfType<KolobokBulletView>().ToArray())
            {
                foreach (var w in _gameObjects.OfType<BrickWallView>().ToArray())
                {
                    if (ObjectCollision(kb, w) || !InScreen(kb))
                    {
                        _gameObjects.Remove(kb);
                    }
                }

                foreach (var t in _gameObjects.OfType<TankView>().ToArray())
                {
                    if (ObjectCollision(kb, t))
                    {
                        _gameObjects.Remove(t);
                        _gameObjects.Remove(kb);
                    }
                }

                kb.Move();
                kb.Draw();
            }
        }

        private void PopulationControl()
        {
            // respawn 
        }

        public void KolobokShoot()
        {
            if (_kolobok.CanShoot && !_gameOver)
            _gameObjects.Add(_kolobok.Shoot());
        }

        private void LoadLevel()
        {
            int offset = 4;
            int posY = 0;

            string path = Path.Combine(Environment.CurrentDirectory, "level.lvl");

            if (File.Exists(path))
            {
                using (StreamReader reader = File.OpenText(path))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        for (int x = 0; x < line.Length; x++)
                        {
                            int posX = x * _WallSize;

                            switch (line[x])
                            {
                                case 'a':
                                    _gameObjects.Add(new AppleView(posX + offset, posY + offset, _GOSize, _GOSize));
                                    break;
                                case 'w':
                                    _gameObjects.Add(new BrickWallView(posX, posY, _WallSize, _WallSize));
                                    break;
                                case 'k':
                                    _kolobok = new KolobokView(posX, posY, _GOSize, _GOSize);
                                    _gameObjects.Add(_kolobok);
                                    break;
                                case 't':
                                    var rndDir = (Direction)rnd.Next(4);
                                    _gameObjects.Add(new TankView(posX + offset, posY + offset, _GOSize, _GOSize, rndDir));
                                    break;
                            }
                        }
                        posY += _WallSize;
                    }
                }
            }
        }
    }
}
