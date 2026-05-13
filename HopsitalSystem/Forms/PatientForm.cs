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
    public partial class PatientForm : Form
    {

        public PatientForm()
        {
            InitializeComponent();
        }

        private void patientsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.patientsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.hopsitalDBDataSet);

        }

        private void PatientForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hopsitalDBDataSet.Patients' table. You can move, or remove it, as needed.
            this.patientsTableAdapter.Fill(this.hopsitalDBDataSet.Patients);

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
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void showAllButton_Click(object sender, EventArgs e)
        {
            this.patientsTableAdapter.Fill(this.hopsitalDBDataSet.Patients);
        }

        private void btnBookAppointment_Click(object sender, EventArgs e)
        {
            if(patientsDataGridView.CurrentRow == null)
            {
                MessageBox.Show("Please select a patient first");
                return;
            }
            int patientID = Convert.ToInt32(
                patientsDataGridView.CurrentRow.Cells[0].Value);
            string patientName = patientsDataGridView.CurrentRow.Cells[1].Value.ToString();

            BookAppointment frm = new BookAppointment(patientID, patientName, this.hopsitalDBDataSet);
            frm.ShowDialog();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
