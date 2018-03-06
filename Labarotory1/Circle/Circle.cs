using System;

namespace Lab1

{
    public class Circle
    {
        public double radius;
        public double area;
        public double perimetre;
        public double diametre;


        public Circle() // empty constructor;
        {
            radius = 15;
            findArea();
            findPerimetre();
            Diametre();
        }

        public Circle(double _radius)
        { // calcгlate S and P;
            radius = _radius;
            findArea();
            findPerimetre();
            Diametre();
        }

        public void findArea() // functions to Find Area and Perimetre;
        {
            area = Math.PI * radius * radius;
        }

        public void findPerimetre()
        {
            perimetre = 2 * Math.PI * radius;
        }
        public void Diametre()
        {
            diametre = 2 * radius;
        }
        public override string ToString(){
            return "Your radius = " + radius + "\nArea = " + area + " Peraimetre = " + perimetre + "\nDiametre " + diametre;;
        }
    }
}
