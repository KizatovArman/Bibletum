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
            int cnt = 0;
            Console.CursorVisible = false;
            int level = 1;
            Body snake = new Body();
            Wall wall = new Wall(level);
            Food food = new Food();



            while (true)
            {
                Console.Clear();
                snake.Draw();
                wall.Draw();
                food.Draw();

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

                }
                if (snake.body[0].x > 29)
                    snake.body[0].x = 0;
                if (snake.body[0].x < 0)
                    snake.body[0].x = 29;
                
                if (snake.CollisionWithWall(wall) || snake.CollisionWithitself())
                {
                    Console.Clear();
                    Console.SetCursorPosition(3, 3);
                    Console.WriteLine("GAME OVER!!!!");
                    Console.ReadKey();
                    snake = new Body();
                    level = 1;
                    wall = new Wall(level);

                }

                if (snake.Kushat(food))
                {
                    food.SetRandompos();
                    cnt++;
                }
                if (cnt>20)
                {
                    level++;
                    cnt = 0;
                }
            }
        }
    }
}
