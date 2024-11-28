namespace WinFormsApp1
{
    partial class Aceitar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Aceitar));
            button8 = new Button();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            label3 = new Label();
            button7 = new Button();
            button10 = new Button();
            pictureBox2 = new PictureBox();
            panelSecretaria = new Panel();
            button11 = new Button();
            button12 = new Button();
            button13 = new Button();
            button14 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panelSecretaria.SuspendLayout();
            SuspendLayout();
            // 
            // button8
            // 
            button8.FlatAppearance.BorderColor = Color.FromArgb(0, 15, 255, 255);
            button8.FlatStyle = FlatStyle.Flat;
            button8.Font = new Font("Segoe UI", 9.75F);
            button8.ForeColor = Color.White;
            button8.Image = (Image)resources.GetObject("button8.Image");
            button8.Location = new Point(3, 400);
            button8.Name = "button8";
            button8.Size = new Size(111, 49);
            button8.TabIndex = 7;
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(216, 190);
            label1.Name = "label1";
            label1.Size = new Size(529, 45);
            label1.TabIndex = 0;
            label1.Text = "Sem pedidos de registro pendentes";
            label1.Visible = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(306, 32);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(282, 248);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            pictureBox1.Visible = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(420, 300);
            label2.Name = "label2";
            label2.Size = new Size(0, 45);
            label2.TabIndex = 13;
            label2.Visible = false;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label3.Font = new Font("Segoe UI", 17F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(120, 300);
            label3.Name = "label3";
            label3.Size = new Size(680, 31);
            label3.TabIndex = 14;
            label3.Text = "Aleatorio";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            label3.Visible = false;
            label3.Click += label3_Click;
            // 
            // button7
            // 
            button7.Location = new Point(306, 386);
            button7.Name = "button7";
            button7.Size = new Size(92, 37);
            button7.TabIndex = 16;
            button7.Text = "Aceitar";
            button7.UseVisualStyleBackColor = true;
            button7.Visible = false;
            button7.Click += button7_Click;
            // 
            // button10
            // 
            button10.Location = new Point(496, 386);
            button10.Name = "button10";
            button10.Size = new Size(92, 37);
            button10.TabIndex = 17;
            button10.Text = "Rejeitar";
            button10.UseVisualStyleBackColor = true;
            button10.Visible = false;
            button10.Click += button10_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(747, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(41, 40);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 18;
            pictureBox2.TabStop = false;
            pictureBox2.Visible = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // panelSecretaria
            // 
            panelSecretaria.BackColor = Color.FromArgb(40, 50, 58);
            panelSecretaria.Controls.Add(button8);
            panelSecretaria.Controls.Add(button11);
            panelSecretaria.Controls.Add(button12);
            panelSecretaria.Controls.Add(button13);
            panelSecretaria.Controls.Add(button14);
            panelSecretaria.Location = new Point(0, 0);
            panelSecretaria.Name = "panelSecretaria";
            panelSecretaria.Size = new Size(114, 449);
            panelSecretaria.TabIndex = 19;
            // 
            // button11
            // 
            button11.FlatStyle = FlatStyle.Flat;
            button11.Image = (Image)resources.GetObject("button11.Image");
            button11.Location = new Point(3, 540);
            button11.Name = "button11";
            button11.Size = new Size(111, 49);
            button11.TabIndex = 5;
            button11.UseVisualStyleBackColor = true;
            // 
            // button12
            // 
            button12.FlatStyle = FlatStyle.Flat;
            button12.Image = (Image)resources.GetObject("button12.Image");
            button12.ImageAlign = ContentAlignment.MiddleLeft;
            button12.Location = new Point(3, 250);
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
            button13.Location = new Point(3, 176);
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
            button14.Location = new Point(3, 109);
            button14.Name = "button14";
            button14.Size = new Size(111, 49);
            button14.TabIndex = 1;
            button14.Text = "   Perfil";
            button14.UseVisualStyleBackColor = true;
            // 
            // Aceitar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(17, 21, 24);
            ClientSize = new Size(800, 450);
            Controls.Add(panelSecretaria);
            Controls.Add(label3);
            Controls.Add(pictureBox2);
            Controls.Add(button10);
            Controls.Add(button7);
            Controls.Add(label2);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "Aceitar";
            Load += Secretaria_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panelSecretaria.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button8;
        private Label label1;
        private PictureBox pictureBox1;
        private Label label2;
        private Label label3;
        private Button button7;
        private Button button10;
        private PictureBox pictureBox2;
        private Panel panelSecretaria;
        private Button button11;
        private Button button12;
        private Button button13;
        private Button button14;
    }
}