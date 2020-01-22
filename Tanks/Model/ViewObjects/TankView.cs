using Model.GameObjects;

namespace Model.ViewObjects
{
    class TankView : Tank
    {
        public TankView(int x, int y, int spriteWidth, int spriteHeight, Direction direction) 
            : base(x, y, spriteWidth, spriteHeight)
        {
            CurrentDirection = direction;

            Sprite = Sprites.Tank_Down;

            BulletWidth = 16;
            BulletHeight = 16;

            Speed = 1;
        }

        public new void Draw()
        {
            switch (CurrentDirection)
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
