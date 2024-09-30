using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // Crie um novo formulário (pop-up)
            Form popupForm = new Form();

            // Adicione os controles necessários ao pop-up
            popupForm.Text = "Formulário de Reclamação/Sugestão";
            popupForm.StartPosition = FormStartPosition.CenterParent;
            popupForm.Size = new Size(300, 200);

            Label lblInstrucao = new Label();
            lblInstrucao.Text = "Escreva sua Reclamação/Sugestão:";
            lblInstrucao.Location = new Point(10, 10);

            TextBox tbMensagem = new TextBox();
            tbMensagem.Multiline = true;
            tbMensagem.ScrollBars = ScrollBars.Vertical;
            tbMensagem.Size = new Size(250, 100);
            tbMensagem.Location = new Point(10, 30);

            Button btnEnviar = new Button();
            btnEnviar.Text = "Enviar";
            btnEnviar.Location = new Point(10, 140);
            btnEnviar.Click += (s, args) =>
            {
                MessageBox.Show("Mensagem Enviada: " + tbMensagem.Text);
                popupForm.Close();
            };

            Button btnFechar = new Button();
            btnFechar.Text = "Fechar";
            btnFechar.Location = new Point(80, 140);
            btnFechar.Click += (s, args) => popupForm.Close();

            popupForm.Controls.Add(lblInstrucao);
            popupForm.Controls.Add(tbMensagem);
            popupForm.Controls.Add(btnEnviar);
            popupForm.Controls.Add(btnFechar);

            // Exiba o pop-up para o usuário
            popupForm.ShowDialog();
        }
    }
}
