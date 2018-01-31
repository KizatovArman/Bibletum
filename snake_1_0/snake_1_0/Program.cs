using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace snake_1_0
{
    class Program
    {
        static void Main(string[] args)
        {
            int level = 1;
            Body snake = new Body();
            Wall wall = new Wall(level);
            Havchik food = new Havchik(level);

            while (true)
            {
                ConsoleKeyInfo keyinfo = Console.ReadKey();
                if (keyinfo.Key == ConsoleKey.UpArrow)
                {
                    snake.Movement(0, -1);
                }
                if (keyinfo.Key == ConsoleKey.DownArrow)
                {
                    snake.Movement(0, 1);
                }
                if (keyinfo.Key == ConsoleKey.RightArrow)
                {
                    snake.Movement(1, 0);
                }
                if (keyinfo.Key == ConsoleKey.LeftArrow)
                {
                    snake.Movement(-1, 0);
                }
                if (keyinfo.Key == ConsoleKey.R)
                {
                    level = 1;
                    snake = new Body();
                    wall = new Wall(level);
                    food = new Havchik(level);
                }
                if (snake.CollisionWithWall(wall) || snake.CollisionWithitself())
                {
                    Console.Clear();
                    Console.SetCursorPosition(5, 5);
                    Console.WriteLine("GAME OVER!!!!");
                    Console.ReadKey();
                    snake = new Body();
                    level = 1;
                    wall = new Wall(level);
                    food = new Havchik(level);
                }
                if (snake.cnt % 10 == 0)
                {
                    level++;
                    wall = new Wall(level);
                }
                Console.Clear();
                snake.Draw();
                wall.Draw();
                food.Draw();
            }
        }
    }
}
