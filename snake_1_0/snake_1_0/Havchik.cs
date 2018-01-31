using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace snake_1_0
{
    public class Havchik
    {
        List<Point> body;
        string znach;
        ConsoleColor color;

        public void ChangeFood(int level)
        {
            StreamReader sr = new StreamReader(@"/Users/arman/Desktop/level" + level + ".txt");
            int n = int.Parse(sr.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string s = sr.ReadLine();
                for (int j = 0; j < s.Length; j++)
                    if (s[j] == 'e')
                        body.Add(new Point(j, i));
            }
            sr.Close();
        }


        public Havchik(int level)
        {
            body = new List<Point>();
            znach = "0";
            color = ConsoleColor.Magenta;
            ChangeFood(level);

        }
        public void Draw()
        {
            Console.ForegroundColor = color;
            foreach (Point p in body)
            {
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(znach);
            }
        }
    }
}
