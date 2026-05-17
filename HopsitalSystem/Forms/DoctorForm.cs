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
    public partial class DoctorForm : Form
    {

        public DoctorForm()
        {
            InitializeComponent();

        }

    

        private void DoctorForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hopsitalDBDataSet.Doctors' table. You can move, or remove it, as needed.
            this.doctorsTableAdapter.Fill(this.hopsitalDBDataSet.Doctors);

        }

        private void btnDrAvailability_Click(object sender, EventArgs e)
        {
            if (doctorsDataGridView.CurrentRow == null)
            {
                MessageBox.Show("Please select a doctor first");
                return;
            }
            int drId = Convert.ToInt32(doctorsDataGridView.CurrentRow.Cells[0].Value);
            string drName = doctorsDataGridView.CurrentRow.Cells[1].Value.ToString();

            DoctorAvailabilityForm frm = new DoctorAvailabilityForm(drId, drName);
            frm.ShowDialog();
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
                this.doctorsTableAdapter.SearchById(
                    this.hopsitalDBDataSet.Doctors,
                     Convert.ToInt32(searchTextBox.Text.Trim())
                    );

                int results = this.hopsitalDBDataSet.Doctors.Count;

                if (results == 0)
                {
                    MessageBox.Show("No Medical Records found matching that name");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.doctorsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.hopsitalDBDataSet);
        }

        private void showAllButton_Click(object sender, EventArgs e)
        {
            this.doctorsTableAdapter.Fill(this.hopsitalDBDataSet.Doctors);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Add frm = new Add("Add Doctor", "Name", "Specialty", "", "");

            if (frm.ShowDialog() == DialogResult.OK)
            {
                doctorsTableAdapter.Insert(
                    frm.value1,
                    frm.value2
                );

                doctorsTableAdapter.Fill(hopsitalDBDataSet.Doctors);
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (doctorsDataGridView.CurrentRow == null)
            {
                MessageBox.Show("Please select a row first.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this row?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
               doctorsBindingSource.RemoveCurrent();

                this.Validate();
               doctorsBindingSource.EndEdit();
                tableAdapterManager.UpdateAll(hopsitalDBDataSet);

                MessageBox.Show("Row deleted successfully.");
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            this.Validate();
            doctorsBindingSource.EndEdit();
            tableAdapterManager.UpdateAll(hopsitalDBDataSet);

            MessageBox.Show("Doctor updated successfully.");
        }
    }
}
