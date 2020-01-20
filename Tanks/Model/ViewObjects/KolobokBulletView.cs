using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.GameObjects
{
    public class KolobokBulletView : MovingObject
    {
        public KolobokBulletView(int x, int y, int spriteWidth, int spriteHeight, Direction direction) //, Bitmap sprite
            : base(x, y, spriteWidth, spriteHeight)//, sprite
        {
            CurrentDirection = direction;

            Sprite = Sprites.KolobokBullet_Up;
            SpriteWidth = 24;
            SpriteHeight = 24;

            Speed = 5;
        }

        public new void Draw()
        {
            switch (CurrentDirection)
            {
                case Direction.Up:
                    Sprite = Sprites.KolobokBullet_Up;
                    break;
                case Direction.Right:
                    Sprite = Sprites.KolobokBullet_Right;
                    break;
                case Direction.Down:
                    Sprite = Sprites.KolobokBullet_Down;
                    break;
                case Direction.Left:
                    Sprite = Sprites.KolobokBullet_Left;
                    break;
            }
        }
    }
}
