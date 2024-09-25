namespace WinFormsApp1
{
    partial class Recuperar2
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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label1.Location = new Point(131, 9);
            label1.Name = "label1";
            label1.Size = new Size(169, 28);
            label1.TabIndex = 0;
            label1.Text = "Recuperar senha";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(90, 73);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(226, 23);
            textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(90, 126);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(226, 23);
            textBox2.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(90, 55);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.TabIndex = 3;
            label2.Text = "Nova senha:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(90, 108);
            label3.Name = "label3";
            label3.Size = new Size(86, 15);
            label3.TabIndex = 4;
            label3.Text = "Repita a senha:";
            // 
            // button1
            // 
            button1.Location = new Point(87, 176);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 5;
            button1.Text = "Recuperar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(254, 176);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 6;
            button2.Text = "Cancelar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Recuperar2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(436, 226);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Recuperar2";
            ShowIcon = false;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label2;
        private Label label3;
        private Button button1;
        private Button button2;
    }
}