using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.GameObjects
{
    public abstract class GameObject
    {
        public Point Position;

        public int Width;
        public int Height;
    
        public Bitmap Sprite;

        public GameObject(int x, int y, int width, int height, Bitmap sprite)
        {
            Position.X = x;
            Position.Y = y;

            Width = width;
            Height = height;

            Sprite = sprite;
        }

        public Bitmap Draw()
        {
            return Sprite;
        }
    }
}
