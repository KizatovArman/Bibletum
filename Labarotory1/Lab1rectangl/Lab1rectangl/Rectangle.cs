using System;

namespace Lab1rectangl
{
    public class Rectangle
    {
        public double width;
        public double lenght;
        public double perimetre;
        public double area;


        public Rectangle()
        {
            width = 123;
            lenght = 230;
            FindArea();
            FindPerimetre();
        }

        public Rectangle(double width, double lenght)
        {
            this.width = width;
            this.lenght = lenght;

        }

        public void FindArea()
        {
            area = width * lenght;
        }

        public void FindPerimetre()
        {
            perimetre = 2 * (width + lenght);
        }


        public override string ToString()
        {
            return "Dimansions are " + width + " " + lenght + "\nArea = " + area + "\nPerimetre = " + perimetre;
        }
    }

}
