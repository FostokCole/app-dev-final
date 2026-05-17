namespace HopsitalSystem.Forms
{
    partial class Add
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Add));
            this.AddLbl = new System.Windows.Forms.Label();
            this.inputText1 = new System.Windows.Forms.Label();
            this.inputText3 = new System.Windows.Forms.Label();
            this.inputText2 = new System.Windows.Forms.Label();
            this.inputText4 = new System.Windows.Forms.Label();
            this.errorLabel = new System.Windows.Forms.Label();
            this.input1 = new System.Windows.Forms.TextBox();
            this.input2 = new System.Windows.Forms.TextBox();
            this.input3 = new System.Windows.Forms.TextBox();
            this.input4 = new System.Windows.Forms.TextBox();
            this.backButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AddLbl
            // 
            resources.ApplyResources(this.AddLbl, "AddLbl");
            this.AddLbl.Name = "AddLbl";
            // 
            // inputText1
            // 
            resources.ApplyResources(this.inputText1, "inputText1");
            this.inputText1.Name = "inputText1";
            // 
            // inputText3
            // 
            resources.ApplyResources(this.inputText3, "inputText3");
            this.inputText3.Name = "inputText3";
            // 
            // inputText2
            // 
            resources.ApplyResources(this.inputText2, "inputText2");
            this.inputText2.Name = "inputText2";
            // 
            // inputText4
            // 
            resources.ApplyResources(this.inputText4, "inputText4");
            this.inputText4.Name = "inputText4";
            // 
            // errorLabel
            // 
            resources.ApplyResources(this.errorLabel, "errorLabel");
            this.errorLabel.Name = "errorLabel";
            // 
            // input1
            // 
            this.input1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.input1, "input1");
            this.input1.Name = "input1";
            // 
            // input2
            // 
            this.input2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.input2, "input2");
            this.input2.Name = "input2";
            // 
            // input3
            // 
            this.input3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.input3, "input3");
            this.input3.Name = "input3";
            // 
            // input4
            // 
            this.input4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.input4, "input4");
            this.input4.Name = "input4";
            // 
            // backButton
            // 
            resources.ApplyResources(this.backButton, "backButton");
            this.backButton.Name = "backButton";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // addButton
            // 
            resources.ApplyResources(this.addButton, "addButton");
            this.addButton.Name = "addButton";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // Add
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.input4);
            this.Controls.Add(this.input3);
            this.Controls.Add(this.input2);
            this.Controls.Add(this.input1);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.inputText4);
            this.Controls.Add(this.inputText2);
            this.Controls.Add(this.inputText3);
            this.Controls.Add(this.inputText1);
            this.Controls.Add(this.AddLbl);
            this.Name = "Add";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label AddLbl;
        private System.Windows.Forms.Label inputText1;
        private System.Windows.Forms.Label inputText3;
        private System.Windows.Forms.Label inputText2;
        private System.Windows.Forms.Label inputText4;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.TextBox input1;
        private System.Windows.Forms.TextBox input2;
        private System.Windows.Forms.TextBox input3;
        private System.Windows.Forms.TextBox input4;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button addButton;
    }
}