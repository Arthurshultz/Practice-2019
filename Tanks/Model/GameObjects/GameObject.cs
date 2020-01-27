using System.Drawing;

namespace Model.GameObjects
{
    public abstract class GameObject
    {
        public Point Position;

        public string Name { get => this.ToString(); }
        public int PosX { get => Position.X; }
        public int PosY { get => Position.Y; }

        public int SpriteWidth;
        public int SpriteHeight;
    
        public Bitmap Sprite;

        public GameObject(int x, int y, int spriteWidth, int spriteHeight)
        {
            Position.X = x;
            Position.Y = y;

            SpriteWidth = spriteWidth;
            SpriteHeight = spriteHeight;
        }

        public Bitmap Draw()
        {
            return Sprite;
        }
    }
}
