namespace WinFormsApp1
{
    partial class DicasPost1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DicasPost1));
            panel1 = new Panel();
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label3 = new Label();
            textBox3 = new TextBox();
            label4 = new Label();
            panel2 = new Panel();
            pictureBox1 = new PictureBox();
            button1 = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(40, 50, 58);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(425, 94);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(50, 35);
            label1.Name = "label1";
            label1.Size = new Size(316, 29);
            label1.TabIndex = 0;
            label1.Text = "Editor de Dicas e Assistencias ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 120);
            label2.Name = "label2";
            label2.Size = new Size(128, 20);
            label2.TabIndex = 1;
            label2.Text = "Escreva o Titulo*";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 143);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(401, 28);
            textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(12, 208);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(401, 28);
            textBox2.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 185);
            label3.Name = "label3";
            label3.Size = new Size(58, 20);
            label3.TabIndex = 4;
            label3.Text = "Autor*";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(12, 272);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(401, 156);
            textBox3.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 249);
            label4.Name = "label4";
            label4.Size = new Size(138, 20);
            label4.TabIndex = 7;
            label4.Text = "Conteudo da Dica*";
            // 
            // panel2
            // 
            panel2.Controls.Add(pictureBox1);
            panel2.Location = new Point(197, 434);
            panel2.Name = "panel2";
            panel2.Size = new Size(216, 111);
            panel2.TabIndex = 10;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(216, 111);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += PictureBox1_Click;
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(21, 445);
            button1.Name = "button1";
            button1.Size = new Size(156, 89);
            button1.TabIndex = 11;
            button1.Text = "Enviar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Button1_Click;
            // 
            // DicasPost1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(17, 21, 24);
            ClientSize = new Size(425, 557);
            Controls.Add(button1);
            Controls.Add(panel2);
            Controls.Add(label4);
            Controls.Add(textBox3);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(panel1);
            Font = new Font("Comic Sans MS", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(4);
            Name = "DicasPost1";
            StartPosition = FormStartPosition.CenterScreen;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label3;
        private TextBox textBox3;
        private Label label4;
        private Panel panel2;
        private PictureBox pictureBox1;
        private Button button1;
    }
}