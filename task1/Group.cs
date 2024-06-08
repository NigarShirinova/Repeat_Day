using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
                                                                                                                                                                
namespace task1
{
    internal class Group
    {
        private static int id = 1;
        public int Id { get; set; }
        public string Name { get; set; }

        public int Limit {  get; set; }
        public CustomList<Student> Students = new CustomList<Student>();
        public Group(string name, int limit)
        {
            Name = name;
            Limit = limit;
            Id = id++;
        }

    }
}
