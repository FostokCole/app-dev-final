using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Models
{
    internal class Doctor
    {
        public int DoctorId { get; set; }
        public string Name { get; set; }
        public string Specialty { get; set; }

        public Doctor(int id, string name, string specialty)
        {
            DoctorId = id;
            Name = name;
            Specialty = specialty;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
