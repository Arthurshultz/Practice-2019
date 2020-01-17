using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.GameObjects
{
    public abstract class Kolobok : MovingObject
    {
        public Kolobok(int x, int y, int width, int height, Bitmap sprite)
            : base(x, y, width, height, sprite)
        {}

        public override void PushOff()
        {
            switch (currentDirection)
            {
                case Direction.Up:
                    Position.Y += 1;
                    currentDirection = Direction.None;
                    break;
                case Direction.Right:
                    Position.X -= 1;
                    currentDirection = Direction.None;
                    break;
                case Direction.Down:
                    Position.Y -= 1;
                    currentDirection = Direction.None;
                    break;
                case Direction.Left:
                    Position.X += 1;
                    currentDirection = Direction.None;
                    break;
            }
        }
    }
}
