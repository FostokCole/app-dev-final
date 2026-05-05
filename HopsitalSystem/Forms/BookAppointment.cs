using HopsitalSystem.HopsitalDBDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HopsitalSystem.Forms
{
    public partial class BookAppointment : Form
    {
        int patID;
        HopsitalDBDataSet datSet;
        AppointmentsTableAdapter appointmentsAdapter = new AppointmentsTableAdapter();
        DoctorsTableAdapter doctorsAdapter = new DoctorsTableAdapter();
        public BookAppointment(int PatientID, string Name, HopsitalDBDataSet dataSet)
        {
            InitializeComponent();
            patID = PatientID;
            datSet = dataSet;
            lblPatientName.Text = Name;
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            if (DoctorComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a doctor");
                return;
            }
            if (appointmentDatePicker.Value < DateTime.Now)
            {
                MessageBox.Show("Cannot book an appointment in the past.");
                return;
            }

            try
            {
                int docID = Convert.ToInt32(DoctorComboBox.SelectedValue);
                DateTime appointmentDate = appointmentDatePicker.Value;

                int conflicts = Convert.ToInt32(
                appointmentsAdapter.IsDoctorBusy(docID, appointmentDate));

                if (conflicts > 0)
                {
                    MessageBox.Show(
                        "This doctor already has an appointment at that time.");
                    return;
                }

                appointmentsAdapter.InsertAppointment(patID, docID, appointmentDate);

                this.Close();
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BookAppointment_Load(object sender, EventArgs e)
        {
            DoctorComboBox.DisplayMember = "Display";
            DoctorComboBox.ValueMember = "DoctorID";
            doctorsAdapter.Fill(datSet.Doctors);

            var doctors = datSet.Doctors
                .Select()
                .Select(row => new
                {
                    DoctorID = row[0],
                    Display = row[1] + " - " + row[2]
                })
                .ToList();

            DoctorComboBox.DataSource = doctors;

            appointmentDatePicker.MinDate = DateTime.Today;
            appointmentDatePicker.Value = DateTime.Today;
        }

    }
}
