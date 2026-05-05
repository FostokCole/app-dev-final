namespace HopsitalSystem.Forms
{
    partial class BookAppointment
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookAppointment));
            this.lblPatientName = new System.Windows.Forms.Label();
            this.DoctorComboBox = new System.Windows.Forms.ComboBox();
            this.btnBook = new System.Windows.Forms.Button();
            this.medicalRecordsTableAdapter1 = new HopsitalSystem.HopsitalDBDataSetTableAdapters.MedicalRecordsTableAdapter();
            this.appointmentDatePicker = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // lblPatientName
            // 
            resources.ApplyResources(this.lblPatientName, "lblPatientName");
            this.lblPatientName.Name = "lblPatientName";
            // 
            // DoctorComboBox
            // 
            resources.ApplyResources(this.DoctorComboBox, "DoctorComboBox");
            this.DoctorComboBox.FormattingEnabled = true;
            this.DoctorComboBox.Name = "DoctorComboBox";
            // 
            // btnBook
            // 
            resources.ApplyResources(this.btnBook, "btnBook");
            this.btnBook.Name = "btnBook";
            this.btnBook.UseVisualStyleBackColor = true;
            this.btnBook.Click += new System.EventHandler(this.btnBook_Click);
            // 
            // medicalRecordsTableAdapter1
            // 
            this.medicalRecordsTableAdapter1.ClearBeforeFill = true;
            // 
            // appointmentDatePicker
            // 
            resources.ApplyResources(this.appointmentDatePicker, "appointmentDatePicker");
            this.appointmentDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.appointmentDatePicker.Name = "appointmentDatePicker";
            // 
            // BookAppointment
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.appointmentDatePicker);
            this.Controls.Add(this.btnBook);
            this.Controls.Add(this.DoctorComboBox);
            this.Controls.Add(this.lblPatientName);
            this.Name = "BookAppointment";
            this.Load += new System.EventHandler(this.BookAppointment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPatientName;
        private System.Windows.Forms.ComboBox DoctorComboBox;
        private System.Windows.Forms.Button btnBook;
        private HopsitalDBDataSetTableAdapters.MedicalRecordsTableAdapter medicalRecordsTableAdapter1;
        private System.Windows.Forms.DateTimePicker appointmentDatePicker;
    }
}