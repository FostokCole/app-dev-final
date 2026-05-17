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
    public partial class AppointmentForm : Form
    {


        public AppointmentForm()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.appointmentsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.hopsitalDBDataSet);

        }

        private void AppointmentForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hopsitalDBDataSet.Appointments' table. You can move, or remove it, as needed.
            this.appointmentsTableAdapter.Fill(this.hopsitalDBDataSet.Appointments);

        }

        private void btnBack_Click(object sender, EventArgs e)
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
                this.appointmentsTableAdapter.SearchById(
                    this.hopsitalDBDataSet.Appointments,
                     Convert.ToInt32(searchTextBox.Text.Trim())
                    );

                int results = this.hopsitalDBDataSet.Appointments.Count;

                if (results == 0)
                {
                    MessageBox.Show("No Appointments found matching that ID");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bookAppointment_Click(object sender, EventArgs e)
        {
            BookAppointment frm = new BookAppointment();
            frm.ShowDialog();
        }

        private void showAllButton_Click(object sender, EventArgs e)
        {
            this.appointmentsTableAdapter.Fill(this.hopsitalDBDataSet.Appointments);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (appointmentsDataGridView.CurrentRow == null)
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
               appointmentsBindingSource.RemoveCurrent();

                this.Validate();
                appointmentsBindingSource.EndEdit();
                tableAdapterManager.UpdateAll(hopsitalDBDataSet);

                MessageBox.Show("Row deleted successfully.");
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            this.Validate();
            appointmentsBindingSource.EndEdit();
            tableAdapterManager.UpdateAll(hopsitalDBDataSet);

            MessageBox.Show("Appointment updated successfully.");
        }
    }
}
