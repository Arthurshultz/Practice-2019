using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.GameObjects
{
    class Tank : MovingObject, IShooter
    {
        public int BulletWidth;
        public int BulletHeight;

        public Tank(int x, int y, int spriteWidth, int spriteHeight) //, Bitmap sprite
            : base(x, y, spriteWidth, spriteHeight) //, sprite
        {}

        public void TurnAround()
        {
            switch (CurrentDirection)
            {
                case Direction.Up:
                    CurrentDirection = Direction.Down;
                    break;
                case Direction.Right:
                    CurrentDirection = Direction.Left;
                    break;
                case Direction.Down:
                    CurrentDirection = Direction.Up;
                    break;
                case Direction.Left:
                    CurrentDirection = Direction.Right;
                    break;
            }
        }

        public void ChangeDirection()
        {
            while (true)
            {
                Random rnd = new Random();
                int rndDir = rnd.Next(4);

                if (rndDir != (int)CurrentDirection)
                {
                    CurrentDirection = (Direction)rndDir;
                    break;
                }
            }
        }

        public GameObject Shoot()
        {
            int posX = 0;
            int posY = 0;

            switch (CurrentDirection)
            {
                case Direction.Up:
                    posX = Position.X + (SpriteWidth / 2) - (BulletWidth / 2);
                    posY = Position.Y - BulletHeight;
                    break;
                case Direction.Right:
                    posX = Position.X + SpriteWidth;
                    posY = Position.Y + (BulletHeight / 2) + (BulletWidth / 2);
                    break;
                case Direction.Down:
                    posX = Position.X + (SpriteWidth / 2) - (BulletWidth / 2);
                    posY = Position.Y + SpriteHeight;
                    break;
                case Direction.Left:
                    posX = Position.X - BulletWidth;
                    posY = Position.Y + (BulletHeight / 2) + (BulletWidth / 2);
                    break;
            }

            return new TankBulletView(posX, posY, SpriteWidth, SpriteHeight, CurrentDirection);
        }
    }
}
