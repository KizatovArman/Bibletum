using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeProject
{
    class Food
    {
        public ConsoleColor color;
        public string sign;
        public Point location;

        public Food()
        {
            sign = "?";
            color = ConsoleColor.Red;
            location = new Point(10, 7);
        }

        public void RandomSpawn()
        {
            int x = new Random().Next(0, 30);
            int y = new Random().Next(0, 15);
            location = new Point(x, y);
        }

        public void Draw()
        {
            Console.ForegroundColor = color;
            Console.WriteLine(sign);
            Console.SetCursorPosition(location._x, location._y);
        }
    }
}