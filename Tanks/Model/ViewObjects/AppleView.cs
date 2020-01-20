using Model.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewObjects
{
    class AppleView : GameObject
    {
        public AppleView(int x, int y, int spriteWidth, int spriteHeight)
            : base(x, y, spriteWidth, spriteHeight)
        {
            Sprite = Sprites.Apple;
        }
    }
}
