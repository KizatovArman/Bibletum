using System;

namespace Lab1

{
    public class Circle
    {
        public double radius;
        public double area;
        public double perimetre;


        public Circle() // empty constructor;
        {
            radius = 15;
        }

        public Circle(double radius)
        { // constructor with some intial data + calcilate S and P;
            this.radius = radius;
            findArea();
            findPerimetre();
        }

        public void findArea() // functions to Find Area and Perimetre;
        {
            area = Math.PI * radius * radius;
        }

        public void findPerimetre()
        {
            perimetre = 2 * Math.PI * radius;
        }

        public override string ToString(){
            return "Your radius = " + radius + "\nArea = " + area + " Peraimetre = " + perimetre;
        }
    }
}
