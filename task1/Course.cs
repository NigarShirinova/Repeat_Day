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
        public List<Group> Groups = new List<Group>();
        public Course(string name)
        {
            
            Name = name;
        }
    }
}
