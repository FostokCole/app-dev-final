using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Models
{
    internal class Appointment
    {
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime Date { get; set; }

        public Appointment(int id, int patientId, int doctorId, DateTime date)
        {
            AppointmentId = id;
            PatientId = patientId;
            DoctorId = doctorId;
            Date = date;
        }
    }
}
