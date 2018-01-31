using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace snake_1_0
{
    public class Body
    {
        List<Point> body;
        ConsoleColor color;
        string znachok;
        public int cnt;
        public Body()
        {
            body = new List<Point>();
            color = ConsoleColor.DarkBlue;
            znachok = "@";
            cnt = 0;
        }

        public void Movement(int dx, int dy)
        {
            
            if ( cnt%1==0)
            {
                body.Add(new Point(0,0));
            }

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

        public bool CollisionWithWall(Wall w)
        {
            foreach(Point p in body)
            {
                if (p.x == body[0].x && p.y == body[0].y)
                    return true;
            }
            return false;
        }

        public bool CollisionWithitself()
        {
            for (int i = body.Count(); i > 0; i++)
            {
                if (body[0].x == body[i].x && body[0].y == body[i].y)
                    return true;
            }
            return false;
        }
        public bool Eating(Havchik h)
        {
            
            foreach (Point p in body)
            {
                if (p.x == body[0].x && p.y == body[0].y)
                {
                    cnt++;
                    return true;
                }
            }
            return false;
        }
    }
}
