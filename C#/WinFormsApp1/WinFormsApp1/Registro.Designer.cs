﻿
namespace WinFormsApp1
{
    partial class Registro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Registro));
            button1 = new Button();
            label3 = new Label();
            label2 = new Label();
            textBox2 = new TextBox();
            label1 = new Label();
            textBox1 = new TextBox();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            comboBox1 = new ComboBox();
            label5 = new Label();
            textBox3 = new TextBox();
            label4 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(66, 318);
            button1.Name = "button1";
            button1.Size = new Size(157, 46);
            button1.TabIndex = 8;
            button1.Text = "Registrar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Comic Sans MS", 9.75F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(18, 132);
            label3.Name = "label3";
            label3.Size = new Size(40, 18);
            label3.TabIndex = 6;
            label3.Text = "Email";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Comic Sans MS", 9.75F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(18, 76);
            label2.Name = "label2";
            label2.Size = new Size(41, 18);
            label2.TabIndex = 5;
            label2.Text = "Nome";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(18, 150);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(262, 23);
            textBox2.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(18, 14);
            label1.Name = "label1";
            label1.Size = new Size(96, 30);
            label1.TabIndex = 4;
            label1.Text = "Registro";
            label1.Click += Label1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(18, 97);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(262, 23);
            textBox1.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(40, 50, 58);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(textBox1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(776, 426);
            panel1.TabIndex = 10;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(335, 14);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(427, 397);
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.ImeMode = ImeMode.Off;
            comboBox1.Items.AddRange(new object[] { "Professor", "Profissional", "Responsavel", "Secretaria" });
            comboBox1.Location = new Point(17, 277);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(263, 23);
            comboBox1.TabIndex = 5;
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Comic Sans MS", 9.75F);
            label5.ForeColor = Color.White;
            label5.Location = new Point(17, 256);
            label5.Name = "label5";
            label5.Size = new Size(102, 18);
            label5.TabIndex = 12;
            label5.Text = "Tipo de usuario";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(18, 212);
            textBox3.Name = "textBox3";
            textBox3.PasswordChar = '*';
            textBox3.Size = new Size(262, 23);
            textBox3.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Comic Sans MS", 9.75F);
            label4.ForeColor = Color.White;
            label4.Location = new Point(18, 194);
            label4.Name = "label4";
            label4.Size = new Size(45, 18);
            label4.TabIndex = 10;
            label4.Text = "Senha";
            // 
            // Registro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.FromArgb(17, 21, 24);
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Registro";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Load += Registro_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

       

        #endregion
        private Button button1;
        private Label label3;
        private Label label2;
        private TextBox textBox2;
        private Label label1;
        private TextBox textBox1;
        private Panel panel1;
        private Label label5;
        private TextBox textBox3;
        private Label label4;
        private ComboBox comboBox1;
        private PictureBox pictureBox1;
    }
}