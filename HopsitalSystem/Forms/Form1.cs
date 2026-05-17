using HopsitalSystem.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HopsitalSystem
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
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void btnDoctors_Click(object sender, EventArgs e)
        {
            DoctorForm frm = new DoctorForm();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void btnAppointments_Click(object sender, EventArgs e)
        {
            AppointmentForm frm = new AppointmentForm();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void btnMR_Click(object sender, EventArgs e)
        {
            MRForm frm = new MRForm();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.appointmentsTableAdapter.Fill(this.hopsitalDBDataSet.Appointments);

            var appointments = this.hopsitalDBDataSet.Appointments
                .OrderBy(a => a.AppointmentDate)
                .ToList();

            patientsDataView.DataSource = appointments;
        }
    }
    }
