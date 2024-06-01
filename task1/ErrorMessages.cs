using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    internal class ErrorMessages
    {
        public void WrongGroupName() { Console.WriteLine("Group name is incorrect"); }
        public void SameGroupName() { Console.WriteLine("This course contains a group with that name"); }
        public void DoesntContainGroup() { Console.WriteLine("This course doesn't contains such as group"); }
        public void WrongStudentNameorSurname() { Console.WriteLine("Student's Name or Surname is wrong"); }
    }
}
