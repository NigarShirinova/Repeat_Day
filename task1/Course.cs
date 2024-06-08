using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    internal class Course
    {
        public string Name { get; set; }
        public CustomList<Group> Groups = new CustomList<Group>();
        public Course(string name)
        {
            
            Name = name;
        }
    }
}
