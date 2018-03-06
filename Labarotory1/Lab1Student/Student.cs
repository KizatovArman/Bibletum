using System;

namespace Lab1Student
{
    public class Student
    {
        public string name;
        public string surname;
        public double gpa1;
        public double gpa2;
        public double gpa3;
        public double gpa4;
        public double gpaaver;

        public Student()
        {
            name = "Arman";
            surname = "Kizatov";
            gpa1 = 4.00;
            gpa2 = 4.00;
            gpa3 = 4.00;
            gpa4 = 4.00;
            FindAverGpa();
        }
        public Student(string _name, string _surname)

        {
            name = _name;
            surname = _surname;
        }

        public Student(string name, string surname, double gpa1, double gpa2, double gpa3, double gpa4)
        {
            this.name = name;
            this.surname = surname;
            this.gpa1 = gpa1;
            this.gpa2 = gpa2;
            this.gpa3 = gpa3;
            this.gpa4 = gpa4;
            FindAverGpa();
        }

        public void FindAverGpa()
        {
            gpaaver = (gpa1 + gpa2 + gpa3 + gpa4) / 4;   
        }

        public override string ToString()
        {
            return name + " " + surname + "\nGPA = " + gpaaver;
        }
    }
}
