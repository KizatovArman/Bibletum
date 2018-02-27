using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeProject
{
    [Serializable]
    class Food
    {
        public ConsoleColor color;
        public string sign;
        public Point location;

        public Food()
        {
            sign = "@";
            color = ConsoleColor.Red;
            location = new Point(10, 7);
        }

        public void RandomSpawn(Wall wall, Snakeitself snake)
        {
            int x = new Random().Next(0, 30);
            int y = new Random().Next(0, 15);
            while (CheckSpawn(wall, snake, x, y))
            {
                x = new Random().Next(0, 30);
                y = new Random().Next(0, 20);
            }
            location = new Point(x, y);
        }

        public bool CheckSpawn(Wall wall, Snakeitself sn, int x, int y)
        {
            for (int i = 0; i < wall.body.Count(); i++)
            {
                for (int j = 0; j < sn.body.Count(); j++)
                {
                    if ((sn.body[j].x == x && sn.body[i].y == y) || (wall.body[i].x == x && wall.body[i].y == y)) ;
                    return true;
                }
            }
            return false;
        }

        public void Draw()
        {
            Console.ForegroundColor = color;
            Console.WriteLine(sign);
            Console.SetCursorPosition(location.x, location.y);
        }
    }
}