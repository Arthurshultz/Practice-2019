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
        public KolobokView(int x, int y, int width, int height, Bitmap sprite)
            : base(x, y, width, height, sprite)
        {

        }

        public void Draw(Direction dir)
        {
            switch (dir)
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
