using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    public class Doctor
    {
        public string Name { get; set; }
        public List<Appointment> Appointments { get; private set; }

        public Doctor()
        {
            Appointments = new List<Appointment>();
        }
    }

}
