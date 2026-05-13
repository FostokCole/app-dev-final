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

        private void doctorsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.doctorsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.hopsitalDBDataSet);

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

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
