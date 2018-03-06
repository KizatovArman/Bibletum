using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeProject
{
    [Serializable]
    public class Food
    {
        public ConsoleColor color;
        public string sign;
        public Point location;

        public Food()
        {
            sign = "@";
            color = ConsoleColor.Red;
            location = new Point(23, 13);
        }

        public void RandomSpawn(Wall wall, Snakeitself snake,Food f)
        {
            int x = new Random().Next(1, 64);
            int y = new Random().Next(1, 28);
            if (CheckSpawn1(snake,f) || ChickingSpawn2(wall,f))
            {
                x = new Random().Next(1, 64);
                y = new Random().Next(1, 28);
            }
            location = new Point(x, y);
        }

        public bool CheckSpawn1(Snakeitself sn,Food food)//, int x, int y)
        {
            for (int j = 1; j < sn.body.Count(); j++)
            {
                if (sn.body[j].x == food.location.x && sn.body[j].y == food.location.y)
                    return true;
            }
            return false;
        }

        public bool ChickingSpawn2(Wall w, Food food2)
        {
            for (int i = 0; i < w.body.Count(); i++)
            {
                if (w.body[i].x == food2.location.x && w.body[i].y == food2.location.y) 
                return true;
            }
            return false;
        }

        public void Draw()
        {
            Console.SetCursorPosition(location.x, location.y);
            Console.ForegroundColor = color;
            Console.WriteLine(sign);
           
        }
    }
}