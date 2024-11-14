namespace WinFormsApp1
{
    partial class Agenda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Agenda));
            panel1 = new Panel();
            button8 = new Button();
            button9 = new Button();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            monthCalendar1 = new MonthCalendar();
            panel2 = new Panel();
            label1 = new Label();
            labelMes = new Label();
            labelDia = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(40, 50, 58);
            panel1.Controls.Add(button8);
            panel1.Controls.Add(button9);
            panel1.Controls.Add(button6);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(118, 450);
            panel1.TabIndex = 12;
            // 
            // button8
            // 
            button8.FlatAppearance.BorderColor = Color.FromArgb(0, 15, 255, 255);
            button8.FlatStyle = FlatStyle.Flat;
            button8.Image = (Image)resources.GetObject("button8.Image");
            button8.Location = new Point(3, 398);
            button8.Name = "button8";
            button8.Size = new Size(111, 49);
            button8.TabIndex = 7;
            button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            button9.FlatStyle = FlatStyle.Flat;
            button9.Image = (Image)resources.GetObject("button9.Image");
            button9.Location = new Point(0, 534);
            button9.Name = "button9";
            button9.Size = new Size(111, 49);
            button9.TabIndex = 6;
            button9.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.FlatAppearance.BorderColor = Color.White;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Image = (Image)resources.GetObject("button6.Image");
            button6.ImageAlign = ContentAlignment.MiddleLeft;
            button6.Location = new Point(3, 307);
            button6.Name = "button6";
            button6.Size = new Size(111, 49);
            button6.TabIndex = 4;
            button6.Text = "   Avisos";
            button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.FlatAppearance.BorderColor = Color.White;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Image = (Image)resources.GetObject("button5.Image");
            button5.ImageAlign = ContentAlignment.MiddleLeft;
            button5.Location = new Point(3, 252);
            button5.Name = "button5";
            button5.Size = new Size(111, 49);
            button5.TabIndex = 3;
            button5.Text = "   Chat";
            button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.FlatAppearance.BorderColor = Color.White;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Image = (Image)resources.GetObject("button4.Image");
            button4.ImageAlign = ContentAlignment.MiddleLeft;
            button4.Location = new Point(3, 197);
            button4.Name = "button4";
            button4.Size = new Size(111, 49);
            button4.TabIndex = 2;
            button4.Text = "   Agenda";
            button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.FlatAppearance.BorderColor = Color.White;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Image = (Image)resources.GetObject("button3.Image");
            button3.ImageAlign = ContentAlignment.MiddleLeft;
            button3.Location = new Point(3, 142);
            button3.Name = "button3";
            button3.Size = new Size(111, 49);
            button3.TabIndex = 1;
            button3.Text = "   Dicas";
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.FlatAppearance.BorderColor = Color.White;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(3, 87);
            button2.Name = "button2";
            button2.Size = new Size(111, 49);
            button2.TabIndex = 1;
            button2.Text = "   Perfil";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.FlatAppearance.BorderColor = Color.White;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(3, 32);
            button1.Name = "button1";
            button1.Size = new Size(111, 49);
            button1.TabIndex = 1;
            button1.Text = "    Home";
            button1.UseVisualStyleBackColor = true;
            // 
            // monthCalendar1
            // 
            monthCalendar1.CalendarDimensions = new Size(2, 3);
            monthCalendar1.Location = new Point(130, -7);
            monthCalendar1.MaxDate = new DateTime(2024, 12, 31, 0, 0, 0, 0);
            monthCalendar1.MaxSelectionCount = 1;
            monthCalendar1.MinDate = new DateTime(2024, 1, 1, 0, 0, 0, 0);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.ShowToday = false;
            monthCalendar1.TabIndex = 13;
            monthCalendar1.DateChanged += monthCalendar1_DateChanged;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(40, 50, 58);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(labelMes);
            panel2.Controls.Add(labelDia);
            panel2.Location = new Point(587, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(213, 450);
            panel2.TabIndex = 14;
            panel2.Visible = false;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 10F);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(3, 58);
            label1.Name = "label1";
            label1.Size = new Size(207, 133);
            label1.TabIndex = 2;
            label1.Text = "label1";
            // 
            // labelMes
            // 
            labelMes.AutoSize = true;
            labelMes.Font = new Font("Segoe UI", 12F);
            labelMes.ForeColor = SystemColors.Control;
            labelMes.Location = new Point(62, 29);
            labelMes.Name = "labelMes";
            labelMes.Size = new Size(97, 21);
            labelMes.TabIndex = 1;
            labelMes.Text = "de fevereiro ";
            // 
            // labelDia
            // 
            labelDia.AutoSize = true;
            labelDia.Font = new Font("Segoe UI", 12F);
            labelDia.ForeColor = SystemColors.Control;
            labelDia.Location = new Point(3, 8);
            labelDia.Name = "labelDia";
            labelDia.Size = new Size(204, 21);
            labelDia.TabIndex = 0;
            labelDia.Text = "Eventos agendados do dia X";
            // 
            // Agenda
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(17, 21, 24);
            ClientSize = new Size(800, 450);
            Controls.Add(panel2);
            Controls.Add(monthCalendar1);
            Controls.Add(panel1);
            Name = "Agenda";
            Text = "Agenda";
            Load += Agenda_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button8;
        private Button button9;
        private Button button6;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
        private MonthCalendar monthCalendar1;
        private Panel panel2;
        private Label labelDia;
        private Label labelMes;
        private Label label1;
    }
}