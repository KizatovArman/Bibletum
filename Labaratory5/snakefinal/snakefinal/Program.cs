using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace snakefinal
{
    class Program
    {
        static Snake snake = new Snake();
        static Wall wall = new Wall(snakefinal.Wall.level);
        static Food food = new Food(snake, wall);
        static int direction = 1;// 1 - left, 2 - right, 3 - up, 4 - down
        static bool canplay = true;
        static int speed = 800;
        static int cnt = 0;

        static void Playthegame()
        {
            while(canplay)
            {
                if (direction == 1)
                    snake.Move(-1, 0,wall);
                if (direction == 2)
                    snake.Move(1, 0,wall);
                if (direction == 3)
                    snake.Move(0, -1,wall);
                if (direction == 4)
                    snake.Move(0, 1,wall);
                Console.Clear();
                snake.Draw();
                wall.Draw();
                food.Draw();
                Thread.Sleep(speed);
            }
        }

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Thread thread = new Thread(Playthegame);
            thread.Start();

            while(canplay)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.UpArrow)
                    direction = 3;
                if (keyInfo.Key == ConsoleKey.DownArrow)
                    direction = 4;
                if (keyInfo.Key == ConsoleKey.LeftArrow)
                    direction = 1;
                if (keyInfo.Key == ConsoleKey.RightArrow)
                    direction = 2;
                if (keyInfo.Key == ConsoleKey.Escape)
                    canplay = false;

                if (snake.Eat(food))
                {
                    cnt++;
                    food = new Food(snake, wall);
                }

                if(cnt%2==0 && cnt!=0)
                {
                    speed = speed - 120;
                }
                if(cnt%10==0)
                {
                    cnt = 0;
                    Wall.level++;
                    snake = new Snake();
                    food = new Food(snake, wall);
                }
            }
        }
    }
}
