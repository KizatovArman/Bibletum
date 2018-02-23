using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace snakefinal
{
    [Serializable]
    public class Wall
    {
        public List<Point> body;
        public char sign;
        public ConsoleColor color;
        public int row;
        public int collumn;
        public static int level;
        public string s;

        public Wall(){
        }

        public void LoadLevel(int level)
        {

            body.Clear();
            StreamReader sr = new StreamReader(@"/Users/arman/Desktop/level" + level + ".txt");
            row = int.Parse(sr.ReadLine());
            for (int i = 0; i < row; i++)
            {
                 s = sr.ReadLine();
                for (int j = 0; j < s.Length; j++)
                    if (s[j] == '*')
                        body.Add(new Point(j, i));
            }
            sr.Close();
            collumn = s.Length;
        }

        public Wall(int u)
        {
            u = level;
            sign = '#';
            color = ConsoleColor.Yellow;
            body = new List<Point>();
            LoadLevel(level);
        }

        public void Draw()
        {
            
            foreach (Point p in body)
            {
                Console.ForegroundColor = color;
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(sign);
            }
        }
    }
}
