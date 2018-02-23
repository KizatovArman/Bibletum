using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;


namespace snake_1_0
{
    class Program
    {
        static int dir = 1; //1 - right , 2 - left , 3 - down , 4 - up
        static int level = 1;
        static Body snake = new Body();
        static Wall wall = new Wall(level);
        static Food food = new Food();
        static int speed = 1000;
        static int cnt = 0;
        static bool game = true;
        public static void F1()
        {
            FileStream fs = new FileStream(@"data.ser", FileMode.Create, FileAccess.Write);

            Body snake = new Body();

            BinaryFormatter bf = new BinaryFormatter();

            try
            {
                bf.Serialize(fs, snake);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                fs.Close();
            }
        }

        public static void fu()
        {
            while(game)
            {
                if (dir == 3)
                    snake.Movement(0, 1);
                if (dir == 4)
                    snake.Movement(0, -1);
                if (dir == 2)
                    snake.Movement(-1, 0);
                if (dir== 1)
                    snake.Movement(1, 0);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                snake.Draw();
                wall.Draw();
                food.Draw();
                if (cnt % 20 == 0)
                    speed = Math.Max(100, speed - 100);
                Thread.Sleep(speed);
            }
        }
        static void Main(string[] args)
        {

            Thread thread = new Thread(fu);
            thread.Start();


            while (true)
            {
                
                ConsoleKeyInfo keyinfo = Console.ReadKey();

                if (keyinfo.Key == ConsoleKey.DownArrow )//&& dir != 4)
                    dir = 3;
                if (keyinfo.Key == ConsoleKey.UpArrow)// && //dir != 3)
                    dir = 4;
                if (keyinfo.Key == ConsoleKey.LeftArrow) //&& dir != 1)
                    dir = 2;
                if (keyinfo.Key == ConsoleKey.RightArrow) //&& dir != 2)
                    dir = 1;

                if (keyinfo.Key == ConsoleKey.R)
                {
                    
                    level = 1;
                    snake = new Body();
                    wall = new Wall(level);

                }
               
                if (snake.Kushat(food) == true)
                {
                    cnt++;
                    food.SetRandompos();

                }
                if (cnt%20==0){
                    level++;
                     wall = new Wall(level);
                }

               if (snake.CollisionWithWall(wall) || snake.CollisionWithitself() == true)
                {
                    game = false;
                    Console.Clear();
                    Console.SetCursorPosition(3, 3);
                    Console.WriteLine("GAME OVER!!!!");
                    Console.ReadKey();
                    snake = new Body();
                    level = 1;
                    wall = new Wall(level);

                }
            }
        }
    }
}
