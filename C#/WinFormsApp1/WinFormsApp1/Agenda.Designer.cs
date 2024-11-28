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
            panelGeral = new Panel();
            button8 = new Button();
            button9 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            monthCalendar1 = new MonthCalendar();
            panel2 = new Panel();
            button10 = new Button();
            label1 = new Label();
            labelMes = new Label();
            labelDia = new Label();
            panelSecretaria = new Panel();
            button5 = new Button();
            button6 = new Button();
            button12 = new Button();
            button13 = new Button();
            button14 = new Button();
            panelGeral.SuspendLayout();
            panel2.SuspendLayout();
            panelSecretaria.SuspendLayout();
            SuspendLayout();
            // 
            // panelGeral
            // 
            panelGeral.BackColor = Color.FromArgb(40, 50, 58);
            panelGeral.Controls.Add(panelSecretaria);
            panelGeral.Controls.Add(button8);
            panelGeral.Controls.Add(button9);
            panelGeral.Controls.Add(button4);
            panelGeral.Controls.Add(button3);
            panelGeral.Controls.Add(button2);
            panelGeral.Controls.Add(button1);
            panelGeral.Dock = DockStyle.Left;
            panelGeral.Location = new Point(0, 0);
            panelGeral.Name = "panelGeral";
            panelGeral.Size = new Size(118, 510);
            panelGeral.TabIndex = 12;
            // 
            // button8
            // 
            button8.FlatAppearance.BorderColor = Color.FromArgb(0, 15, 255, 255);
            button8.FlatStyle = FlatStyle.Flat;
            button8.Font = new Font("Comic Sans MS", 9F);
            button8.ForeColor = Color.White;
            button8.Image = (Image)resources.GetObject("button8.Image");
            button8.Location = new Point(3, 451);
            button8.Name = "button8";
            button8.Size = new Size(111, 56);
            button8.TabIndex = 7;
            button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            button9.FlatStyle = FlatStyle.Flat;
            button9.Image = (Image)resources.GetObject("button9.Image");
            button9.Location = new Point(0, 605);
            button9.Name = "button9";
            button9.Size = new Size(111, 56);
            button9.TabIndex = 6;
            button9.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.FlatAppearance.BorderColor = Color.White;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Comic Sans MS", 9F);
            button4.ForeColor = Color.White;
            button4.Image = (Image)resources.GetObject("button4.Image");
            button4.ImageAlign = ContentAlignment.MiddleLeft;
            button4.Location = new Point(7, 292);
            button4.Name = "button4";
            button4.Size = new Size(111, 56);
            button4.TabIndex = 2;
            button4.Text = "   Agenda";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.FlatAppearance.BorderColor = Color.White;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Comic Sans MS", 9F);
            button3.ForeColor = Color.White;
            button3.Image = (Image)resources.GetObject("button3.Image");
            button3.ImageAlign = ContentAlignment.MiddleLeft;
            button3.Location = new Point(7, 230);
            button3.Name = "button3";
            button3.Size = new Size(111, 56);
            button3.TabIndex = 1;
            button3.Text = "   Dicas";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.FlatAppearance.BorderColor = Color.White;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Comic Sans MS", 9F);
            button2.ForeColor = Color.White;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(7, 168);
            button2.Name = "button2";
            button2.Size = new Size(111, 56);
            button2.TabIndex = 1;
            button2.Text = "   Perfil";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.FlatAppearance.BorderColor = Color.White;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Comic Sans MS", 9F);
            button1.ForeColor = Color.White;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(7, 105);
            button1.Name = "button1";
            button1.Size = new Size(111, 56);
            button1.TabIndex = 1;
            button1.Text = "    Home";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // monthCalendar1
            // 
            monthCalendar1.CalendarDimensions = new Size(2, 3);
            monthCalendar1.Location = new Point(126, 9);
            monthCalendar1.Margin = new Padding(9, 10, 9, 10);
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
            panel2.Controls.Add(button10);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(labelMes);
            panel2.Controls.Add(labelDia);
            panel2.Location = new Point(587, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(213, 510);
            panel2.TabIndex = 14;
            panel2.Visible = false;
            // 
            // button10
            // 
            button10.FlatAppearance.BorderColor = Color.White;
            button10.FlatStyle = FlatStyle.Flat;
            button10.ForeColor = Color.White;
            button10.ImageAlign = ContentAlignment.MiddleLeft;
            button10.Location = new Point(13, 424);
            button10.Name = "button10";
            button10.Size = new Size(188, 56);
            button10.TabIndex = 8;
            button10.Text = "Agendar novo compromisso";
            button10.UseVisualStyleBackColor = true;
            button10.Visible = false;
            button10.Click += button10_Click;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 10F);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(3, 66);
            label1.Name = "label1";
            label1.Size = new Size(207, 355);
            label1.TabIndex = 2;
            label1.Text = "label1";
            // 
            // labelMes
            // 
            labelMes.AutoSize = true;
            labelMes.Font = new Font("Segoe UI", 12F);
            labelMes.ForeColor = SystemColors.Control;
            labelMes.Location = new Point(62, 33);
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
            labelDia.Location = new Point(3, 9);
            labelDia.Name = "labelDia";
            labelDia.Size = new Size(204, 21);
            labelDia.TabIndex = 0;
            labelDia.Text = "Eventos agendados do dia X";
            // 
            // panelSecretaria
            // 
            panelSecretaria.BackColor = Color.FromArgb(40, 50, 58);
            panelSecretaria.Controls.Add(button5);
            panelSecretaria.Controls.Add(button6);
            panelSecretaria.Controls.Add(button12);
            panelSecretaria.Controls.Add(button13);
            panelSecretaria.Controls.Add(button14);
            panelSecretaria.Location = new Point(2, -8);
            panelSecretaria.Name = "panelSecretaria";
            panelSecretaria.Size = new Size(116, 517);
            panelSecretaria.TabIndex = 8;
            panelSecretaria.Visible = false;
            panelSecretaria.Paint += panelSecretaria_Paint;
            // 
            // button5
            // 
            button5.FlatStyle = FlatStyle.Flat;
            button5.Image = (Image)resources.GetObject("button5.Image");
            button5.ImageAlign = ContentAlignment.MiddleLeft;
            button5.Location = new Point(3, 141);
            button5.Name = "button5";
            button5.Size = new Size(111, 49);
            button5.TabIndex = 6;
            button5.Text = "    Home";
            button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.FlatStyle = FlatStyle.Flat;
            button6.Image = (Image)resources.GetObject("button6.Image");
            button6.Location = new Point(4, 466);
            button6.Name = "button6";
            button6.Size = new Size(111, 49);
            button6.TabIndex = 5;
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click_2;
            // 
            // button12
            // 
            button12.FlatStyle = FlatStyle.Flat;
            button12.Image = (Image)resources.GetObject("button12.Image");
            button12.ImageAlign = ContentAlignment.MiddleLeft;
            button12.Location = new Point(3, 325);
            button12.Name = "button12";
            button12.Size = new Size(111, 49);
            button12.TabIndex = 2;
            button12.Text = "   Agenda";
            button12.UseVisualStyleBackColor = true;
            // 
            // button13
            // 
            button13.FlatStyle = FlatStyle.Flat;
            button13.Image = (Image)resources.GetObject("button13.Image");
            button13.ImageAlign = ContentAlignment.MiddleLeft;
            button13.Location = new Point(4, 264);
            button13.Name = "button13";
            button13.Size = new Size(111, 49);
            button13.TabIndex = 1;
            button13.Text = "    Registros";
            button13.UseVisualStyleBackColor = true;
            // 
            // button14
            // 
            button14.FlatStyle = FlatStyle.Flat;
            button14.Image = (Image)resources.GetObject("button14.Image");
            button14.ImageAlign = ContentAlignment.MiddleLeft;
            button14.Location = new Point(5, 205);
            button14.Name = "button14";
            button14.Size = new Size(111, 49);
            button14.TabIndex = 1;
            button14.Text = "   Perfil";
            button14.UseVisualStyleBackColor = true;
            // 
            // Agenda
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(17, 21, 24);
            ClientSize = new Size(800, 510);
            Controls.Add(panel2);
            Controls.Add(monthCalendar1);
            Controls.Add(panelGeral);
            Font = new Font("Comic Sans MS", 9F);
            ForeColor = Color.White;
            Name = "Agenda";
            Text = "Agenda";
            Load += Agenda_Load;
            panelGeral.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panelSecretaria.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelGeral;
        private Button button8;
        private Button button9;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
        private MonthCalendar monthCalendar1;
        private Panel panel2;
        private Label labelDia;
        private Label labelMes;
        private Label label1;
        private Button button10;
        private Panel panelSecretaria;
        private Button button5;
        private Button button6;
        private Button button12;
        private Button button13;
        private Button button14;
    }
}