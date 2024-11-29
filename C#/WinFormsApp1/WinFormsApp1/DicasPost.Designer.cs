namespace WinFormsApp1
{
    partial class DicasPost
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DicasPost));
            panel1 = new Panel();
            button7 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            button8 = new Button();
            label1 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(40, 50, 58);
            panel1.Controls.Add(button7);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(114, 599);
            panel1.TabIndex = 1;
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
            // button4
            // 
            button4.FlatStyle = FlatStyle.Flat;
            button4.Image = (Image)resources.GetObject("button4.Image");
            button4.ImageAlign = ContentAlignment.MiddleLeft;
            button4.Location = new Point(3, 343);
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
            button3.Location = new Point(3, 288);
            button3.Name = "button3";
            button3.Size = new Size(111, 49);
            button3.TabIndex = 1;
            button3.Text = "   Dicas";
            button3.UseVisualStyleBackColor = true;
            button3.Click += Button3_Click;
            // 
            // button2
            // 
            button2.FlatStyle = FlatStyle.Flat;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(3, 233);
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
            button1.Location = new Point(3, 178);
            button1.Name = "button1";
            button1.Size = new Size(111, 49);
            button1.TabIndex = 1;
            button1.Text = "    Home";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Button1_Click;
            // 
            // button8
            // 
            button8.FlatStyle = FlatStyle.Flat;
            button8.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button8.Location = new Point(642, 14);
            button8.Name = "button8";
            button8.Size = new Size(160, 37);
            button8.TabIndex = 4;
            button8.Text = "Submeta as dicas";
            button8.UseVisualStyleBackColor = true;
            button8.Click += Button8_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(135, 18);
            label1.Name = "label1";
            label1.Size = new Size(311, 33);
            label1.TabIndex = 5;
            label1.Text = "Sessão de Dicas e Auxilios";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(120, 54);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(682, 533);
            flowLayoutPanel1.TabIndex = 6;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.Paint += FlowLayoutPanel1_Paint;
            // 
            // DicasPost
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(17, 21, 24);
            ClientSize = new Size(814, 599);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(label1);
            Controls.Add(button8);
            Controls.Add(panel1);
            Font = new Font("Comic Sans MS", 9F);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "DicasPost";
            StartPosition = FormStartPosition.CenterScreen;
            Load += DicasPost_Load;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button button7;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
        private Button button8;
        private Label label1;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}