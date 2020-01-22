using Model.GameObjects;
using System.Drawing;

namespace Model.ViewObjects
{
    class BrickWallView : GameObject
    {
        public bool IsDestroible;
        public bool IsMissesBullet;


        public BrickWallView(int x, int y, int spriteWidth, int spriteHeight, Bitmap sprite, bool isDestroible, bool isMissesBullet)
            : base(x, y, spriteWidth, spriteHeight)
        {
            Sprite = sprite;
            IsDestroible = isDestroible;
            IsMissesBullet = isMissesBullet;
        }
    }
}
