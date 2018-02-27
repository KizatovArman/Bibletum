using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace SnakeProject
{
    [Serializable]
    class Snakeitself
    {
        public ConsoleColor color;
        public string sign;
        public List<Point> body;

        public Snakeitself()
        {
            color = ConsoleColor.Green;
            sign = "O";
            body = new List<Point>();
            body.Add(new Point(2, 2));
           
        }

        public void SnakeSer()
        {
            XmlSerializer xss = new XmlSerializer(typeof(Snakeitself));
            FileStream fsss = new FileStream("snake.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            xss.Serialize(fsss,this);
            fsss.Close();
        }

        public Snakeitself Deser()
        {
            XmlSerializer sxx = new XmlSerializer(typeof(Snakeitself));
            FileStream sfff = new FileStream("snake.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            Snakeitself snake = sxx.Deserialize(sfff) as Snakeitself;
            sfff.Close();
            return snake;
        }

        public void Draw()
        {
            int ind = 0;
            foreach (Point p in body)
            {
                if (ind == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                else
                    Console.ForegroundColor = color;
                Console.SetCursorPosition(p.x, p.y);
                Console.WriteLine(sign);
                ind++;
            }
        }

        public void Movement(int dx, int dy)
        {
            for (int i = body.Count - 1; i > 0; i--)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }

            body[0].x = body[0].x + dx;
            body[0].y = body[0].y + dy;
        }

        public bool FoodEating(Food food)
        {
            if (body[0].x == food.location.x && body[0].y == food.location.y)
            {
                body.Add(new Point(body[body.Count() - 1].x, body[body.Count() - 1].y));
                return true;
            }
            return false;
        }

        public bool CollisionWithWallandSnake(Snakeitself snake, Wall w)
        {
            for (int i = 0; i < snake.body.Count(); i++)
            {
                for (int j = 0; j < w.body.Count(); j++)
                {
                    if ((snake.body[0].x == snake.body[i].x && snake.body[0].y == snake.body[i].y) || (snake.body[0].x == w.body[j].x && snake.body[0].y == w.body[j].y));
                    return true;
                }
            }
            return false;
        }
    }
}