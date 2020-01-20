using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.GameObjects
{
    class TankBulletView: MovingObject
    {
        public TankBulletView(int x, int y, int spriteWidth, int spriteHeight, Direction direction) //, Bitmap sprite
            : base(x, y, spriteWidth, spriteHeight)//, sprite
        {
            CurrentDirection = direction;

            Sprite = Sprites.TankBullet_Up;
            SpriteWidth = 8;
            SpriteHeight = 8;

            Speed = 5;
        }

        public new void Draw()
        {
            switch (CurrentDirection)
            {
                case Direction.Up:
                    Sprite = Sprites.TankBullet_Up;
                    break;
                case Direction.Right:
                    Sprite = Sprites.TankBullet_Right;
                    break;
                case Direction.Down:
                    Sprite = Sprites.TankBullet_Down;
                    break;
                case Direction.Left:
                    Sprite = Sprites.TankBullet_Left;
                    break;
            }
        }
    }
}
