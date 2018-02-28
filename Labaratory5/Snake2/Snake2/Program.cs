using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Threading;

namespace SnakeProject
{
    [Serializable]
    class Program
    {
        static public Snakeitself snake = new Snakeitself();
        static public int lvl = 1;
        static public Wall wall = new Wall(lvl);
        static public Food food = new Food();
        static public int direction = 1;
        static public int speed = 650;
        static public bool canplay = true;

        public static void Game()// тут мы создаем дополнительный поток который одновременно с Main потоком двигает змейку в определенном направлении изначально вниз и смотрим функции кушать столкновение и смену левела
        {
            while(canplay)
            {
                if (direction == 1)
                    snake.Movement(0, 1);
                if (direction == 2)
                    snake.Movement(0, -1);
                if (direction == 3)
                    snake.Movement(1, 0);
                if (direction == 4)
                    snake.Movement(-1, 0);

                if(snake.body.Count()%20==0)
                {
                    lvl++;
                    wall.LevelChanger(lvl);
                    snake = new Snakeitself();
                    speed = 650;
                    food = new Food();
                    wall = new Wall();
                    snake.Draw();
                    wall.Draw();
                    food.Draw();
                    //canplay = true;
                }

                if(snake.FoodEating(food))
                {
                    snake.body.Add(new Point(snake.body[snake.body.Count() - 1].x, snake.body[snake.body.Count() - 1].y));


                    if(snake.body.Count()%5 == 0 && speed >= 100)
                    {
                        speed -= 150;
                    }
                    food.RandomSpawn(wall,snake,food);
                }
                
                if (snake.CollisionWithWall(wall)== true || snake.CollisionwithSnake(snake) == true)//если произошло столкновение со стеной или с телом
                {
                    canplay = false;
                    Console.WriteLine("GAME OVER");
                    Console.ReadKey();
                }
                snake.Draw();
                wall.Draw();
                food.Draw();
                Console.BackgroundColor = ConsoleColor.Black;
                Thread.Sleep(speed);
                Console.Clear();
            }
        }

        static void Main(string[] args)//тут у нас Main поток в котором мы нажимаем кнопочки чтобы менять направления
        {
            Console.CursorVisible = false;

            Thread th = new Thread(Game);
            th.Start();
            while(canplay)
            {
                
                ConsoleKeyInfo ki = Console.ReadKey();
                if (ki.Key == ConsoleKey.S)// сохраняем наши змейку и стенку
                {
                    snake.SnakeSer();
                    wall.F1();
                }
                if (ki.Key == ConsoleKey.B)// с последнего сохранения
                {
                    Console.Clear();
                    snake = snake.Deser();
                    wall = wall.F2();
                    //Console.ReadKey();
                }
                if (ki.Key == ConsoleKey.UpArrow)
                    direction = 2;
                if (ki.Key == ConsoleKey.DownArrow)
                    direction = 1;
                if (ki.Key == ConsoleKey.RightArrow)
                    direction = 3;
                if (ki.Key == ConsoleKey.LeftArrow)
                    direction = 4;
            }
        }
    }
}