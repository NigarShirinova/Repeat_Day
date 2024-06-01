using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    internal class Student
    {
        private static int id = 1;
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public int Age { get; set; }
        public double Grade { get; set; }

        public Student(string name, string surname, int age, double grade)
        {
            Name = name;
            SurName = surname;
            Age = age;
            Grade = grade;
            Id = id;
            Id = id++;

        }
    }
}
