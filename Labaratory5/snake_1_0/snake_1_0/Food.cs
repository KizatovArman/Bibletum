using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake_1_0
{
    public class Food
    {
        
        public ConsoleColor color;
        public Point coordinate;
        public string sign; 

        public Food()
        {
            sign = "@";
            color = ConsoleColor.Gray;
            coordinate = new Point(10, 10);
        }

       

        public void SetRandompos()
        {
            int x = new Random().Next(0, 29);
            int y = new Random().Next(0, 14);
            coordinate = new Point(x, y);
        }

        public void Draw()
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(coordinate.x, coordinate.y);
            Console.Write(sign);
        }
    }
}
