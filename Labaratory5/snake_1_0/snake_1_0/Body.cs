using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace snake_1_0
{
     class Body
    {
        public List<Point> body;
        public ConsoleColor color;
        public string znachok;
        public Body()
        {
            body = new List<Point>();
            color = ConsoleColor.DarkBlue;
            znachok = "@";

            body.Add(new Point(2,2));
            body.Add(new Point(2,3));

        }

        public void Movement(int dx, int dy)
        {
              for (int i = body.Count() - 1; i > 0; i++)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }
            body[0].x += dx;
            body[0].y += dy;
        }

        public void Draw()
        {
            int index = 0;
            foreach(Point p in body)
            {
                if (index == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                    Console.ForegroundColor = color;
                Console.SetCursorPosition(p.x , p.y);
                Console.Write(znachok);
                index++;
            }
        }

        public bool Kushat(Food f)
        {
            if (body[0].x == f.coordinate.x && body[0].y == f.coordinate.y)
            {
                body.Add(new Point(body[body.Count - 1].x, body[body.Count - 1].y));
                return true;
            }
            return false;
        }

        public bool CollisionWithWall(Wall w)
        {
            bool res2 = true;
            foreach(Point p in body)
            {
                if (p.x == body[0].x && p.y == body[0].y)
                    res2 = true;;
            }
            res2 = false;

            return res2;
        }

        /*public bool CollisionWithitself()
        {
            bool res = true;
            for (int i = body.Count(); i > 0; i++)
            {
                if (body[0].x == body[i].x && body[0].y == body[i].y)
                    res = true;
            }
            res =false;

            return res;
        }
        */

    }
}
