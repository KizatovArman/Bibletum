using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeProject
{
    class Wall
    {
        public string sign;
        public List<Point> body;
        public ConsoleColor color;

        public void LevelChanger(int lvl)
        {
            StreamReader sr = new StreamReader(@"/Users/arman/Desktop/level" + lvl + ".txt");
            int n = int.Parse(sr.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string s = sr.ReadLine();
                for (int j = 0; j < s.Length; j++)
                    if (s[j] == '*')
                        body.Add(new Point(j, i));
            }
            sr.Close();
        }

        public Wall(int lvl)
        {
            body = new List<Point>();
            sign = "*";
            color = ConsoleColor.Yellow;
            LevelChanger(lvl);
        }
        public void Draw()
        {
            Console.ForegroundColor = color;
            foreach (Point p in body)
            {
                Console.SetCursorPosition(p._x, p._y);
                Console.WriteLine(sign);
            }
        }
    }
}