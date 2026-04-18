using HospitalManagementSystem.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalManagementSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnPatients_Click(object sender, EventArgs e)
        {
            PatientForm frm = new PatientForm();
            frm.Show();
        }

        private void btnDoctors_Click(object sender, EventArgs e)
        {
            DoctorForm frm = new DoctorForm();
            frm.Show();
        }

        private void btnAppointments_Click(object sender, EventArgs e)
        {
            AppointmentForm frm = new AppointmentForm();
            frm.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
