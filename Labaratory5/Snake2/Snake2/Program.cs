using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.SetWindowSize(20, 15);
            Console.CursorVisible = false;
            int level = 1;
            Snakeitself snake = new Snakeitself();
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

                if (snake.FoodEating(food))
                {
                    food.RandomSpawn();
                }

                if (snake.CollisionWithWall(wall) || snake.CollisionItsefl())
                {
                    Console.Clear();
                    Console.SetCursorPosition(3, 3);
                    Console.WriteLine("GAME OVER!!!!");
                    Console.ReadKey();
                    snake = new Snakeitself();
                    level = 1;
                    wall = new Wall(level);
                    food.RandomSpawn();

                }
            }
        }
    }
}