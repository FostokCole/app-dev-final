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

    
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.patientsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.hopsitalDBDataSet);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Add frm = new Add("Add Patient", "Name", "Age", "Phone", "");

            if (frm.ShowDialog() == DialogResult.OK)
            {
                patientsTableAdapter.Insert(
                    frm.value1,
                    Convert.ToInt32(frm.value2),
                    frm.value3
                );

                patientsTableAdapter.Fill(hopsitalDBDataSet.Patients);
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            this.Validate();

            patientsBindingSource.EndEdit();

            tableAdapterManager.UpdateAll(hopsitalDBDataSet);

            MessageBox.Show("Updated successfully.");
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (patientsDataGridView.CurrentRow == null)
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
                patientsBindingSource.RemoveCurrent();

                this.Validate();
                patientsBindingSource.EndEdit();
                tableAdapterManager.UpdateAll(hopsitalDBDataSet);

                MessageBox.Show("Row deleted successfully.");
            }
        }
    }
}
