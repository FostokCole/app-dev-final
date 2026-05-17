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
        public BookAppointment()
        {
            InitializeComponent();
        }
        private void bookButton_Click(object sender, EventArgs e)
        {
            if (patientsDataView.CurrentRow == null)
            {
                MessageBox.Show("Please select a patient first.");
                return;
            }

            if (DoctorComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a doctor.");
                return;
            }

            patID = Convert.ToInt32(
                patientsDataView.CurrentRow.Cells[0].Value
            );

            int docID = Convert.ToInt32(DoctorComboBox.SelectedValue);
            DateTime appointmentDate = appointmentDatePicker.Value;

            int conflicts = Convert.ToInt32(
                appointmentsAdapter.IsDoctorBusy(docID, appointmentDate)
            );

            if (conflicts > 0)
            {
                MessageBox.Show("This doctor already has an appointment at that time.");
                return;
            }

            appointmentsAdapter.InsertAppointment(patID, docID, appointmentDate);

            MessageBox.Show("Appointment booked successfully.");
            this.Close();
        }

        private void BookAppointment_Load(object sender, EventArgs e)
        {
            try
            {
                doctorsAdapter.Fill(this.hopsitalDBDataSet.Doctors);

                var doctors = this.hopsitalDBDataSet.Doctors
                    .Select()
                    .Select(row => new
                    {
                        DoctorID = Convert.ToInt32(row["DoctorId"]),
                        Display = row["Name"].ToString() + " - " + row["Specialty"].ToString()
                    })
                    .ToList();

                DoctorComboBox.DataSource = doctors;
                DoctorComboBox.DisplayMember = "Display";
                DoctorComboBox.ValueMember = "DoctorID";
                DoctorComboBox.SelectedIndex = -1;

                appointmentDatePicker.MinDate = DateTime.Today;
                appointmentDatePicker.Value = DateTime.Today;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            patientsTableAdapter.Fill(this.hopsitalDBDataSet.Patients);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnBookAppointment_Click(object sender, EventArgs e)
        {
            if (patientsDataView.CurrentRow == null)
            {
                MessageBox.Show("Please select a patient first");
                return;
            }
            int patientID = Convert.ToInt32(
               patientsDataView.CurrentRow.Cells[0].Value);
            string patientName = patientsDataView.CurrentRow.Cells[1].Value.ToString();

            BookAppointment frm = new BookAppointment(patientID, patientName, this.hopsitalDBDataSet);
            frm.ShowDialog();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
          
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(searchTextBox.Text))
            {
                MessageBox.Show("Enter a name to search");
                return;
            }
            try
            {
                this.patientsTableAdapter.SearchByName(
                    this.hopsitalDBDataSet.Patients,
                    searchTextBox.Text.Trim()
                    );

                int results = this.hopsitalDBDataSet.Patients.Count;

                if (results == 0)
                {
                    MessageBox.Show("No Patients found matching that name");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void showAllButton_Click(object sender, EventArgs e)
        {
            this.patientsTableAdapter.Fill(this.hopsitalDBDataSet.Patients);
        }
    }
}
