using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SnakeProject
{ 
    [Serializable]
    public class Wall
    {
        public string sign;
        public List<Point> body;
        public ConsoleColor color;

        public void F1()
        {
            XmlSerializer xs = new XmlSerializer(typeof(Wall));
            FileStream fs = new FileStream("wall.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            xs.Serialize(fs, this);
            fs.Close();
        }

        public Wall F2()
        {
            XmlSerializer sx = new XmlSerializer(typeof(Wall));
            FileStream sf = new FileStream("wall.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            Wall wall = sx.Deserialize(sf) as Wall;
            return wall;
        }

        public void LevelChanger(int lvl)
        {
            StreamReader sr = new StreamReader(@"/Users/arman/Documents/Bibletum/Labaratory5/level" + lvl + ".txt");
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
        public Wall()
        {}

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
                Console.SetCursorPosition(p.x, p.y);
                Console.WriteLine(sign);
            }
        }
    }
}