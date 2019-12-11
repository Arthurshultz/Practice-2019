using System;

namespace Snake
{
    class FoodCreator
    {
        int _mapWidht;
        int _mapHigt;
        char _sym;

        Random rnd = new Random();

        public FoodCreator(int mapWidht, int mapHigt, char sym)
        {
            _mapWidht = mapWidht;
            _mapHigt = mapHigt;
            _sym = sym;
        }

        internal Point CreateFood()
        {
            int x = rnd.Next(2, _mapWidht - 2);
            int y = rnd.Next(2, _mapHigt - 2);
            return new Point(x, y, _sym);
        }
    }
}
