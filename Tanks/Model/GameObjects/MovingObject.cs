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
        public Direction CurrentDirection;
        public int Speed;

        public MovingObject(int x, int y, int spriteWidth, int spriteHeight) //, Bitmap sprite
            : base(x, y, spriteWidth, spriteHeight)//, sprite
        { }

        public void Move()
        {
            switch (CurrentDirection)
            {
                case Direction.Up: Position.Y -= Speed;
                    break;
                case Direction.Right: Position.X += Speed;
                    break;
                case Direction.Down: Position.Y += Speed;
                    break;
                case Direction.Left: Position.X -= Speed;
                    break;
            }
        }

        public virtual void PushOff()
        {
            switch (CurrentDirection)
            {
                case Direction.Up:
                    Position.Y += 2;
                    break;
                case Direction.Right:
                    Position.X -= 2;
                    break;
                case Direction.Down:
                    Position.Y -= 2;
                    break;
                case Direction.Left:
                    Position.X += 2;
                    break;
            }
        }
    }
}
