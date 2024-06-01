using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    public class Hospital
    {
        public List<Doctor> Doctors { get; private set; }

        public Hospital()
        {
            Doctors = new List<Doctor>();
        }

        public void AddDoctor(Doctor doctor)
        {
            Doctors.Add(doctor);
        }
    }
}
