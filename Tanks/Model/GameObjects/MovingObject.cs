using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Model.GameObjects
{
    public abstract class MovingObject : GameObject
    {
        public Direction currentDirection;

        public MovingObject(int x, int y, int width, int height, Bitmap sprite) 
            : base(x, y, width,  height, sprite)
        {}

        public void Move()
        {
            switch (currentDirection)
            {
                case Direction.Up: Position.Y -= 1;
                    break;
                case Direction.Right: Position.X += 1;
                    break;
                case Direction.Down: Position.Y += 1;
                    break;
                case Direction.Left: Position.X -= 1;
                    break;
            }
        }

        public virtual void PushOff()
        {
            switch (currentDirection)
            {
                case Direction.Up:
                    Position.Y += 1;
                    break;
                case Direction.Right:
                    Position.X -= 1;
                    break;
                case Direction.Down:
                    Position.Y -= 1;
                    break;
                case Direction.Left:
                    Position.X += 1;
                    break;
            }
        }
    }
}
