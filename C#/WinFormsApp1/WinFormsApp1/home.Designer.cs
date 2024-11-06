namespace WinFormsApp1
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            panel1 = new Panel();
            button7 = new Button();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            panel2 = new Panel();
            button8 = new Button();
            label2 = new Label();
            label1 = new Label();
            panel3 = new Panel();
            panel4 = new Panel();
            label3 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(40, 50, 58);
            panel1.Controls.Add(button7);
            panel1.Controls.Add(button6);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(114, 601);
            panel1.TabIndex = 0;
            // 
            // button7
            // 
            button7.FlatStyle = FlatStyle.Flat;
            button7.Image = (Image)resources.GetObject("button7.Image");
            button7.Location = new Point(3, 540);
            button7.Name = "button7";
            button7.Size = new Size(111, 49);
            button7.TabIndex = 5;
            button7.UseVisualStyleBackColor = true;
            button7.Click += Button7_Click;
            // 
            // button6
            // 
            button6.FlatStyle = FlatStyle.Flat;
            button6.Image = (Image)resources.GetObject("button6.Image");
            button6.ImageAlign = ContentAlignment.MiddleLeft;
            button6.Location = new Point(3, 368);
            button6.Name = "button6";
            button6.Size = new Size(111, 49);
            button6.TabIndex = 4;
            button6.Text = "   Avisos";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button5
            // 
            button5.FlatStyle = FlatStyle.Flat;
            button5.Image = (Image)resources.GetObject("button5.Image");
            button5.ImageAlign = ContentAlignment.MiddleLeft;
            button5.Location = new Point(3, 313);
            button5.Name = "button5";
            button5.Size = new Size(111, 49);
            button5.TabIndex = 3;
            button5.Text = "   Chat";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.FlatStyle = FlatStyle.Flat;
            button4.Image = (Image)resources.GetObject("button4.Image");
            button4.ImageAlign = ContentAlignment.MiddleLeft;
            button4.Location = new Point(3, 258);
            button4.Name = "button4";
            button4.Size = new Size(111, 49);
            button4.TabIndex = 2;
            button4.Text = "   Agenda";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.FlatStyle = FlatStyle.Flat;
            button3.Image = (Image)resources.GetObject("button3.Image");
            button3.ImageAlign = ContentAlignment.MiddleLeft;
            button3.Location = new Point(3, 203);
            button3.Name = "button3";
            button3.Size = new Size(111, 49);
            button3.TabIndex = 1;
            button3.Text = "   Dicas";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.FlatStyle = FlatStyle.Flat;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(3, 148);
            button2.Name = "button2";
            button2.Size = new Size(111, 49);
            button2.TabIndex = 1;
            button2.Text = "   Perfil";
            button2.UseVisualStyleBackColor = true;
            button2.Click += Button2_Click;
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(3, 93);
            button1.Name = "button1";
            button1.Size = new Size(111, 49);
            button1.TabIndex = 1;
            button1.Text = "    Home";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Button1_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(40, 50, 58);
            panel2.Controls.Add(button8);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(826, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(202, 601);
            panel2.TabIndex = 1;
            // 
            // button8
            // 
            button8.BackColor = Color.FromArgb(40, 50, 58);
            button8.Cursor = Cursors.Hand;
            button8.FlatStyle = FlatStyle.Flat;
            button8.Location = new Point(3, 67);
            button8.Name = "button8";
            button8.Size = new Size(196, 47);
            button8.TabIndex = 4;
            button8.Text = "Clique para escrever";
            button8.UseVisualStyleBackColor = false;
            button8.Click += Button8_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.FlatStyle = FlatStyle.Flat;
            label2.Font = new Font("Comic Sans MS", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(44, 35);
            label2.Name = "label2";
            label2.Size = new Size(130, 29);
            label2.TabIndex = 3;
            label2.Text = "e Sugestões";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Comic Sans MS", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 5);
            label1.Name = "label1";
            label1.Size = new Size(154, 33);
            label1.TabIndex = 2;
            label1.Text = "Reclamações";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(40, 50, 58);
            panel3.Location = new Point(829, 120);
            panel3.Name = "panel3";
            panel3.Size = new Size(196, 478);
            panel3.TabIndex = 5;
            panel3.Paint += Panel3_Paint;
            // 
            // panel4
            // 
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(label3);
            panel4.Location = new Point(120, 14);
            panel4.Name = "panel4";
            panel4.Size = new Size(700, 575);
            panel4.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.FlatStyle = FlatStyle.Flat;
            label3.Font = new Font("Comic Sans MS", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(175, 20);
            label3.TabIndex = 0;
            label3.Text = "Central de Notificações";
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(17, 21, 24);
            ClientSize = new Size(1028, 601);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Home";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Home";
            Load += Home_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button7;
        private Button button6;
        private Button button5;
        private Button button4;
        private Panel panel2;
        private Label label2;
        private Label label1;
        private Button button8;
        private Panel panel3;
        private Panel panel4;
        private Label label3;
    }
}