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

        private void medicalRecordsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
