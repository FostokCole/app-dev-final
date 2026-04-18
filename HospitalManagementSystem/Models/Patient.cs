using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Models
{
    internal class Patient
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }


        public Patient(int id, string name, int age, string phone)
        {
            PatientId = id;
            Name = name;
            Age = age;
            Phone = phone;
        }
    }
}