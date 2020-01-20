using Model.GameObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewObjects
{
    public class KolobokView : Kolobok
    {
        public KolobokView(int x, int y, int spriteWidth, int spriteHeight) //, Bitmap sprite
            : base(x, y, spriteWidth, spriteHeight) //, sprite
        {
            Sprite = Sprites.Kolobok_Right;

            BulletWidth = 24;
            BulletHeight = 24;

            Speed = 1;
        }

        public new void Draw()
        {
            switch (CurrentDirection)
            {
                case Direction.Right:
                    Sprite = Sprites.Kolobok_Right;
                    break;
                case Direction.Left:
                    Sprite = Sprites.Kolobok_Left;
                    break;
            }
        }
    }
}
