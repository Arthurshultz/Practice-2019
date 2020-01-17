using Model.GameObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewObjects
{
    class TankView : Tank
    {
        public TankView(int x, int y, int width, int height, Bitmap sprite)
            : base(x, y, width, height, sprite)
        {}

        public new void Draw()
        {
            switch (currentDirection)
            {
                case Direction.Up:
                    Sprite = Sprites.Tank_Up;
                    break;
                case Direction.Right:
                    Sprite = Sprites.Tank_Right;
                    break;
                case Direction.Down:
                    Sprite = Sprites.Tank_Down;
                    break;
                case Direction.Left:
                    Sprite = Sprites.Tank_Left;
                    break;
            }
        }
    }
}
