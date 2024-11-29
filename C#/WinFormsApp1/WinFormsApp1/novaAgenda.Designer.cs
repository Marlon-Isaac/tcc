namespace WinFormsApp1
{
    partial class novaAgenda
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
            label1 = new Label();
            panel1 = new Panel();
            label3 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            button1 = new Button();
            button2 = new Button();
            comboBox1 = new ComboBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(27, 39);
            label1.Name = "label1";
            label1.Size = new Size(181, 23);
            label1.TabIndex = 0;
            label1.Text = "Editor de compromissos";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(40, 50, 58);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-7, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(338, 96);
            panel1.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Comic Sans MS", 11.25F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(12, 117);
            label3.Name = "label3";
            label3.Size = new Size(164, 20);
            label3.TabIndex = 3;
            label3.Text = "Nome do compromisso:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 140);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(196, 25);
            textBox1.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Comic Sans MS", 11.25F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(9, 177);
            label2.Name = "label2";
            label2.Size = new Size(179, 20);
            label2.TabIndex = 5;
            label2.Text = "Horario do compromisso:";
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Comic Sans MS", 11.25F);
            button1.ForeColor = Color.White;
            button1.Location = new Point(12, 241);
            button1.Name = "button1";
            button1.Size = new Size(82, 28);
            button1.TabIndex = 7;
            button1.Text = "Salvar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Comic Sans MS", 11.25F);
            button2.ForeColor = Color.White;
            button2.Location = new Point(126, 241);
            button2.Name = "button2";
            button2.Size = new Size(82, 28);
            button2.TabIndex = 8;
            button2.Text = "Cancelar";
            button2.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(9, 200);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(199, 23);
            comboBox1.TabIndex = 9;
            // 
            // novaAgenda
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(17, 21, 24);
            ClientSize = new Size(220, 345);
            Controls.Add(comboBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "novaAgenda";
            Load += novaAgenda_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Label label3;
        private TextBox textBox1;
        private Label label2;
        private Button button1;
        private Button button2;
        private ComboBox comboBox1;
    }
}