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
            frm.ShowDialog();
            this.Hide();
        }

        private void btnDoctors_Click(object sender, EventArgs e)
        {
            DoctorForm frm = new DoctorForm();
            frm.ShowDialog();
            this.Hide();
        }

        

        private void btnMR_Click(object sender, EventArgs e)
        {
            MRForm frm = new MRForm();
            frm.ShowDialog();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Hide();
        }

        private void btnAppointments_Click(object sender, EventArgs e)
        {
            AppointmentForm frm = new AppointmentForm();
            frm.ShowDialog();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
                    Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en");
                    break;
                case 1:
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("fr");
                    Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("fr");
                    break;
                case 2:
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("es");
                    Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es");
                    break;
            }
            this.Controls.Clear();
            InitializeComponent();
        }
    }
}
