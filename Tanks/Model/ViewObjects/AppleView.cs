using Model.GameObjects;

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
