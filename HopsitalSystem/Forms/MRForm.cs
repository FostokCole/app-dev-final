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
    public partial class MRForm : Form
    {

        public MRForm()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.medicalRecordsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.hopsitalDBDataSet);

        }

        private void MRForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hopsitalDBDataSet.MedicalRecords' table. You can move, or remove it, as needed.
            this.medicalRecordsTableAdapter.Fill(this.hopsitalDBDataSet.MedicalRecords);
            
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
                this.medicalRecordsTableAdapter.SearchById(
                    this.hopsitalDBDataSet.MedicalRecords,
                     Convert.ToInt32(searchTextBox.Text.Trim())
                    );

                int results = this.hopsitalDBDataSet.MedicalRecords.Count;

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

        private void showAllButton_Click(object sender, EventArgs e)
        {
            this.medicalRecordsTableAdapter.Fill(this.hopsitalDBDataSet.MedicalRecords);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Add frm = new Add("Add Medical Record", "Patient ID", "Diagnosis", "Treatment", "");

            if (frm.ShowDialog() == DialogResult.OK)
            {
                medicalRecordsTableAdapter.Insert(
                    Convert.ToInt32(frm.value1),
                    frm.value2,
                    frm.value3
                );

                medicalRecordsTableAdapter.Fill(hopsitalDBDataSet.MedicalRecords);
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (medicalRecordsDataGridView.CurrentRow == null)
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
                medicalRecordsBindingSource.RemoveCurrent();

                this.Validate();
               medicalRecordsBindingSource.EndEdit();
                tableAdapterManager.UpdateAll(hopsitalDBDataSet);

                MessageBox.Show("Row deleted successfully.");
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            this.Validate();
            medicalRecordsBindingSource.EndEdit();
            tableAdapterManager.UpdateAll(hopsitalDBDataSet);

            MessageBox.Show("Medical record updated successfully.");
        }
    }
}
