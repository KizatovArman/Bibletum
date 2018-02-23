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
        static int level = 1;
        static Snake s = new Snake();
        static Wall wl = new Wall(level);
        static Food food = new Food(s, wl);
        //static int luchshiyres = -1;
        //static int exception = 0;
        static int direction = 1; // 1 - left, 2 - right, 3 - up, 4 - down
        static bool gameOver = false;
        static int speed = 750;
        static int score = 0;

        static void Playgame()
        {
            while(!gameOver)
            {
                if (direction == 1)
                    s.Move(-1, 0,wl);
                if (direction == 2)
                    s.Move(1, 0,wl);
                if (direction == 3)
                    s.Move(0, -1,wl);
                if (direction == 4)
                    s.Move(0, 1,wl);

                Console.Clear();
                s.Draw();
                wl.Draw();
                food.Draw();

                if (score % 4 == 0)
                {
                    speed = Math.Max(speed - 100, 50);
                }
                Thread.Sleep(speed);
            }
        }

        static void Main(string[] args)
        {
            //level = 1;
            //Console.CursorVisible = false;
            //s.CheckPlayer();
            //Console.Clear();


            //food.Draw();

            //string s1 = "Score = 0";
            //string s2 = "Level = 1";
            //s.Draw();
            Thread th = new Thread(Playgame);
            th.Start();
            while (true)//!gameOver)
            {
                /*wl.Draw();
                for (int i = 0; i < s1.Length; i++)
                {
                    Console.SetCursorPosition(i, wl.row);
                    Console.Write(" ");
                }
                Console.SetCursorPosition(0, wl.row);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(s1);
                Console.Write(s2);

                if (s.Eat(food))
                {
                    s.body.Add(new Point(0, 0));
                    food = new Food(s, wl);
                    //food.Draw();
                    score ++;
                    s1 = "Score = " + score.ToString();
                }*/
                ConsoleKeyInfo keyinfo = Console.ReadKey();
                if (keyinfo.Key == ConsoleKey.UpArrow && direction!=4)
                    direction = 3;
                if (keyinfo.Key == ConsoleKey.DownArrow && direction!=3)
                    direction = 4;
                if (keyinfo.Key == ConsoleKey.LeftArrow && direction!= 2)
                    direction = 1;
                if (keyinfo.Key == ConsoleKey.RightArrow && direction!= 1)
                    direction = 2;
            }
        }
    }
}
