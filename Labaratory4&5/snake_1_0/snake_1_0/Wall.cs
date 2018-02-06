using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace snake_1_0
{
    public class Wall
    {
        public List<Point> body;
        public string sign;
        public ConsoleColor color;

        public void ChangeLevels(int level)
        {
            StreamReader sr = new StreamReader(@"/Users/arman/Desktop/level" + level + ".txt");
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

        public Wall(int level)
        {
            body = new List<Point>();
            sign = "8";
            color = ConsoleColor.Green;
            ChangeLevels(level);
        }

        public void Draw()
        {
            Console.ForegroundColor = color;
            foreach(Point p in body)
            {
                Console.SetCursorPosition(p.x,p.y);
                Console.Write(sign);
            }
        }
    }
}
