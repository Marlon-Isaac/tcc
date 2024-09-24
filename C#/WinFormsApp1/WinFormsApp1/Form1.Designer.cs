namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
<<<<<<< HEAD
=======
            comboBox1 = new ComboBox();
>>>>>>> b7fce41258b56fedf55407f7319b4b61f2dd8afe
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label1 = new Label();
            panel1 = new Panel();
            button2 = new Button();
<<<<<<< HEAD
            label4 = new Label();
            button1 = new Button();
=======
            button1 = new Button();
            label4 = new Label();
>>>>>>> b7fce41258b56fedf55407f7319b4b61f2dd8afe
            label3 = new Label();
            label2 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
<<<<<<< HEAD
            // textBox1
            // 
            resources.ApplyResources(textBox1, "textBox1");
            textBox1.BackColor = SystemColors.Window;
            textBox1.ForeColor = SystemColors.ActiveCaptionText;
            textBox1.Name = "textBox1";
=======
            // comboBox1
            // 
            resources.ApplyResources(comboBox1, "comboBox1");
            comboBox1.AllowDrop = true;
            comboBox1.Cursor = Cursors.IBeam;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { resources.GetString("comboBox1.Items"), resources.GetString("comboBox1.Items1"), resources.GetString("comboBox1.Items2"), resources.GetString("comboBox1.Items3"), resources.GetString("comboBox1.Items4") });
            comboBox1.Name = "comboBox1";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // textBox1
            // 
            resources.ApplyResources(textBox1, "textBox1");
            textBox1.Name = "textBox1";
            textBox1.TextChanged += textBox1_TextChanged;
>>>>>>> b7fce41258b56fedf55407f7319b4b61f2dd8afe
            // 
            // textBox2
            // 
            resources.ApplyResources(textBox2, "textBox2");
<<<<<<< HEAD
            textBox2.BackColor = SystemColors.Window;
            textBox2.ForeColor = SystemColors.ActiveCaptionText;
=======
>>>>>>> b7fce41258b56fedf55407f7319b4b61f2dd8afe
            textBox2.Name = "textBox2";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
<<<<<<< HEAD
            label1.UseWaitCursor = true;
=======
>>>>>>> b7fce41258b56fedf55407f7319b4b61f2dd8afe
            label1.Click += label1_Click;
            // 
            // panel1
            // 
            resources.ApplyResources(panel1, "panel1");
<<<<<<< HEAD
            panel1.BackColor = SystemColors.Window;
            panel1.Controls.Add(button2);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(button1);
=======
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label4);
>>>>>>> b7fce41258b56fedf55407f7319b4b61f2dd8afe
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(textBox1);
<<<<<<< HEAD
            panel1.ForeColor = Color.Black;
            panel1.Name = "panel1";
            panel1.TabStop = true;
            panel1.PaddingChanged += panel1_PaddingChanged;
=======
            panel1.Controls.Add(comboBox1);
            panel1.Name = "panel1";
>>>>>>> b7fce41258b56fedf55407f7319b4b61f2dd8afe
            panel1.Paint += panel1_Paint;
            // 
            // button2
            // 
            resources.ApplyResources(button2, "button2");
            button2.Name = "button2";
            button2.UseVisualStyleBackColor = true;
<<<<<<< HEAD
            button2.Click += button2_Click_1;
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.Cursor = Cursors.Hand;
            label4.FlatStyle = FlatStyle.Popup;
            label4.Name = "label4";
            label4.Click += label4_Click;
=======
            button2.Click += button2_Click;
>>>>>>> b7fce41258b56fedf55407f7319b4b61f2dd8afe
            // 
            // button1
            // 
            resources.ApplyResources(button1, "button1");
            button1.Name = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
<<<<<<< HEAD
=======
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            // 
>>>>>>> b7fce41258b56fedf55407f7319b4b61f2dd8afe
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
<<<<<<< HEAD
            label3.UseWaitCursor = true;
=======
>>>>>>> b7fce41258b56fedf55407f7319b4b61f2dd8afe
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
<<<<<<< HEAD
            label2.UseWaitCursor = true;
            label2.Click += label2_Click;
=======
>>>>>>> b7fce41258b56fedf55407f7319b4b61f2dd8afe
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnablePreventFocusChange;
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            ShowIcon = false;
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
<<<<<<< HEAD
=======
        private ComboBox comboBox1;
>>>>>>> b7fce41258b56fedf55407f7319b4b61f2dd8afe
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
        private Panel panel1;
<<<<<<< HEAD
        private Label label3;
        private Label label2;
        private Button button1;
        private Label label4;
=======
        private Label label4;
        private Label label3;
        private Label label2;
        private Button button1;
>>>>>>> b7fce41258b56fedf55407f7319b4b61f2dd8afe
        private Button button2;
    }
}
