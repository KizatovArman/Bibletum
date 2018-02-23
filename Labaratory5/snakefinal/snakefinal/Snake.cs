using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace snakefinal
{
    [Serializable]
    public class Snake
    {
        public int sluchai = 1;
        public string maxiscore;
        public string name;
        public List<Point> body;
        public char sign;
        public ConsoleColor color;

        public Snake()
        {
            sign = 'O';
            color = ConsoleColor.Green;
            body = new List<Point>();
            body.Add(new Point(3, 2));
        }

        public void Move(int dx, int dy,Wall wall)
        {
            Point lastPoint = body[body.Count - 1];
            Console.SetCursorPosition(lastPoint.x, lastPoint.y);
            Console.Write(' ');


            for (int i = body.Count - 1; i > 0; i--)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }

            body[0].x = body[0].x + dx;
            body[0].y = body[0].y + dy;

            if (body[0].x > wall.row)
                body[0].x = 1;
            if (body[0].x < 0)
                body[0].x = wall.row - 1;
            if (body[0].y > wall.collumn)
                body[0].y = 1;
            if (body[0].y < 0)
                body[0].y = wall.collumn - 1;
        }

        public bool CollisionWithWall(Wall w)
        {
            foreach (Point p in w.body)
            {
                if (body[0].x == p.x && body[0].y == p.y && p.x != 0 && p.y != 0 && p.x != w.collumn && p.y != w.row) 
                    return true;
            }
            return false;
        }

        public bool Eat(Food f)
        {
            if (body[0].x == f.location.x && body[0].y == f.location.y)
            {
                return true;
            }
            return false;
        }

        public bool Collisionwithsnake()
        {
            for (int i = 1; i < body.Count; i++)
            {
                if (body[0].x == body[i].x && body[0].y == body[i].y)
                    return true;
            }
            return false;
        }

        public void Draw()
        {
            int index = 0;
            foreach (Point p in body)
            {
                if (index == 0)
                    Console.ForegroundColor = ConsoleColor.Red;
                else
                    Console.ForegroundColor = color;
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(sign);
                index++;
            }
        }

        public void CheckPlayer()
        {
            Console.WriteLine("Hello stranger," + " "+ "please enter your nickname and get ready to start playing");
            name = Console.ReadLine();
            if (File.Exists(@"/Users/arman/Documents/Bibletum/Labaratory5/snakefinal" + name + ".txt") == true)
            {
                sluchai = 2;
                Console.Clear();
                StreamReader sr = new StreamReader(@"/Users/arman/Documents/Bibletum/Labaratory5/snakefinal" + name + ".txt");
                maxiscore = sr.ReadToEnd();
                Console.WriteLine("Hi "+ name + "!");
                Console.WriteLine("Your highest score is "+ maxiscore);
            }
            else
            {
                sluchai = 1;
                Console.Clear();
                Console.WriteLine("Hello, " + name + "!");
                Console.WriteLine("Please enjoy! It is your first try!");
            }
            Console.ReadKey();
        }
    }
}
