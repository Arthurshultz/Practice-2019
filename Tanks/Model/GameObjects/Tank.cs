using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.GameObjects
{
    class Tank : MovingObject
    {
        public Tank(int x, int y, int width, int height, Bitmap sprite)
            : base(x, y, width, height, sprite)
        { }

        public void TurnAround()
        {
            switch (currentDirection)
            {
                case Direction.Up:
                    currentDirection = Direction.Down;
                    break;
                case Direction.Right:
                    currentDirection = Direction.Left;
                    break;
                case Direction.Down:
                    currentDirection = Direction.Up;
                    break;
                case Direction.Left:
                    currentDirection = Direction.Right;
                    break;
            }
        }

        public void ChangeDirection()
        {
            while (true)
            {
                Random rnd = new Random();
                int rndDir = rnd.Next(4);

                if (rndDir != (int)currentDirection)
                {
                    currentDirection = (Direction)rndDir;
                    break;
                }
            }
        }
    }
}
