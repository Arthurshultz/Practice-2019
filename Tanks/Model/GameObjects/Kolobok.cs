using System.Timers;

namespace Model.GameObjects
{
    public abstract class Kolobok : MovingObject, IShooter
    {
        public int BulletWidth;
        public int BulletHeight;

        public bool CanShoot = true;
        
        public Kolobok(int x, int y, int spriteWidth, int spriteHeight)
            : base(x, y, spriteWidth, spriteHeight)
        { }

        public override void PushOff()
        {
            switch (CurrentDirection)
            {
                case Direction.Up:
                    Position.Y += 1;
                    CurrentDirection = Direction.None;
                    break;
                case Direction.Right:
                    Position.X -= 1;
                    CurrentDirection = Direction.None;
                    break;
                case Direction.Down:
                    Position.Y -= 1;
                    CurrentDirection = Direction.None;
                    break;
                case Direction.Left:
                    Position.X += 1;
                    CurrentDirection = Direction.None;
                    break;
            }
        }

        public GameObject Shoot()
        {
            int posX = 0;
            int posY = 0;

            switch (CurrentDirection)
            {
                case Direction.Up:
                    posX = Position.X + (SpriteWidth / 2) - (BulletWidth / 2);
                    posY = Position.Y - BulletHeight;
                    break;
                case Direction.Right:
                    posX = Position.X + SpriteWidth;
                    posY = Position.Y + (BulletHeight / 2);
                    break;
                case Direction.Down:
                    posX = Position.X + (SpriteWidth / 2) - (BulletWidth / 2);
                    posY = Position.Y + SpriteHeight;
                    break;
                case Direction.Left:
                    posX = Position.X - BulletWidth;
                    posY = Position.Y + (BulletHeight / 2);
                    break;
            }

            return new KolobokBulletView(posX, posY, SpriteWidth, SpriteHeight, CurrentDirection);
        }
    }
}
