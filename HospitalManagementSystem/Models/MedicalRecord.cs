using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Models
{
    internal class MedicalRecord
    {
        public int RecordId { get; set; }
        public int PatientId { get; set; }

        public string Diagnosis { get; set; }
        public string Treatment { get; set; }

        public MedicalRecord(int id, int patientId, string diagnosis, string treatment)
        {
            RecordId = id;
            PatientId = patientId;
            Diagnosis = diagnosis;
            Treatment = treatment;
        }
    }
}
