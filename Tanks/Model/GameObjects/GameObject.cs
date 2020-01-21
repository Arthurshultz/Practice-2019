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

        public int SpriteWidth;
        public int SpriteHeight;
    
        public Bitmap Sprite;


        public GameObject(int x, int y, int spriteWidth, int spriteHeight) //, Bitmap sprite
        {
            Position.X = x;
            Position.Y = y;

            SpriteWidth = spriteWidth;
            SpriteHeight = spriteHeight;

            //Sprite = sprite;
        }

        public Bitmap Draw()
        {
            return Sprite;
        }
    }
}
