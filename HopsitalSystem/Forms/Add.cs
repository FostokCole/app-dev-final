using System;
using System.Windows.Forms;

namespace HopsitalSystem.Forms
{
    public partial class Add : Form
    {
        public string value1;
        public string value2;
        public string value3;
        public string value4;

        public Add(string title, string label1, string label2, string label3, string label4)
        {
            InitializeComponent();

            AddLbl.Text = title;

            inputText1.Text = label1;
            inputText2.Text = label2;
            inputText3.Text = label3;
            inputText4.Text = label4;

            if (label3 == "")
            {
                inputText3.Visible = false;
                input3.Visible = false;
            }

            if (label4 == "")
            {
                inputText4.Visible = false;
                input4.Visible = false;
            }

            errorLabel.Text = "";
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (input1.Text.Trim() == "" || input2.Text.Trim() == "")
            {
                errorLabel.Text = "Please fill in all fields.";
                return;
            }

            if (input3.Visible == true && input3.Text.Trim() == "")
            {
                errorLabel.Text = "Please fill in all fields.";
                return;
            }

            if (input4.Visible == true && input4.Text.Trim() == "")
            {
                errorLabel.Text = "Please fill in all fields.";
                return;
            }

            value1 = input1.Text.Trim();
            value2 = input2.Text.Trim();
            value3 = input3.Text.Trim();
            value4 = input4.Text.Trim();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Add_Load(object sender, EventArgs e)
        {

        }
    }
}