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
    public class Snakeitself
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

        public void SnakeSer()//сериализируем
        {
            XmlSerializer xss = new XmlSerializer(typeof(Snakeitself));
            FileStream fsss = new FileStream("snake.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            xss.Serialize(fsss,this);
            fsss.Close();
        }

        public Snakeitself Deser()//десериализируем
        {
            XmlSerializer sxx = new XmlSerializer(typeof(Snakeitself));
            FileStream sfff = new FileStream("snake.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            Snakeitself snake = sxx.Deserialize(sfff) as Snakeitself;
            sfff.Close();
            return snake;
        }

        public void Draw()//прорисовываем 
        {
            int ind = 0;
            foreach (Point p in body)
            {
                if (ind == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                    Console.ForegroundColor = color;
                Console.SetCursorPosition(p.x, p.y);
                Console.WriteLine(sign);
                ind++;
            }
        }

        public void Movement(int dx, int dy)//перемещяем последнюю точку на место предпоследней когда движемся
        {
            for (int i = body.Count - 1; i > 0; i--)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }

            body[0].x = body[0].x + dx;
            body[0].y = body[0].y + dy;
        }

        public bool FoodEating(Food food)//кушаем
        {
            if (body[0].x == food.location.x && body[0].y == food.location.y)
            {
                return true;
            }
            return false;
        }

        public bool CollisionwithSnake(Snakeitself s)
        {
            for (int i = 1; i < s.body.Count(); i++)
            {
                if (body[0].x == s.body[i].x && body[0].y == s.body[i].y)
                    return true;
            }
            return false;
        }

        public bool CollisionWithWall( Wall w)// тут  проверяем если мы стукаемся со стенкой 
        {
            for (int i = 0; i < w.body.Count(); i++)
            {
                if (body[0].x == w.body[i].x && body[0].y == w.body[i].y)
                    return true;
            }
            return false;
        }
    }
}