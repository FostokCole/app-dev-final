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
    public partial class DoctorAvailabilityForm : Form
    {
        public DoctorAvailabilityForm()
        {
            InitializeComponent();
        }

        private void appointmentsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.appointmentsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.hopsitalDBDataSet);

        }

        private void DoctorAvailabilityForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hopsitalDBDataSet.Appointments' table. You can move, or remove it, as needed.
            this.appointmentsTableAdapter.Fill(this.hopsitalDBDataSet.Appointments);

        }
    }
}
