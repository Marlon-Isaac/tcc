﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Chat : Form
    {


        public Chat()
        {
            InitializeComponent();

        }


        private void Chat_Load(object sender, EventArgs e)
        {
            BancoC();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        public void BancoC()
        {
            while (true)
            {
                Banco banco = new Banco();
                using (SqlConnection conn = new SqlConnection(banco.conexao))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Chat WHERE UsuarioRemetenteId = @id OR UsuarioDestinatarioId = @id", conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int remetente = Convert.ToInt32(reader["UsuarioRemetenteId"]);
                                int destinatario = Convert.ToInt32(reader["UsuarioDestinatarioId"]);
                                string mensagem = reader["Conteudo"].ToString();
                                string data = reader["DataEnvio"].ToString();
                                bool lida = Convert.ToBoolean(reader["Lida"]);
                                ObterImagem obterImagem = new ObterImagem();
                                byte[] imagem;
                                if (remetente == SessaoUsuario.UsuarioLogadoId)
                                {
                                    imagem = obterImagem.Obter(destinatario);
                                }
                                else
                                {
                                    imagem = obterImagem.Obter(remetente);
                                }
                                construir(remetente,destinatario,mensagem,data,lida,imagem);
                            }
                        }
                    }
                }
            }
        }
        public void construir(int remetente, int destinatario, string mensagem, string data, bool lida, byte[] imagem)
        {
            // Criar o Panel menor
            Panel panelMensagem = new Panel
            {
                Size = new Size(600, 180),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.LightGray,
                Margin = new Padding(10)
            };

            // Adicionar evento de clique para abrir o formulário "Conversa"
            panelMensagem.Click += (s, e) =>
            {
                Conversa conversa = new Conversa();
                conversa.Show();
                this.Hide();
            };

            // Criar a PictureBox para exibir a imagem
            PictureBox pictureBox = new PictureBox
            {
                Size = new Size(90, 90),
                Location = new Point(10, 10),
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.Zoom
            };

            // Converter byte[] para imagem e atribuir à PictureBox
            if (imagem != null)
            {
                using (MemoryStream ms = new MemoryStream(imagem))
                {
                    pictureBox.Image = Image.FromStream(ms);
                }
            }

            // Criar Label para o nome do usuário
            Label labelNome = new Label
            {
                Text = remetente.ToString(), // Substitua com o nome do usuário
                Font = new Font("Comic Sans MS", 15),
                Location = new Point(110, 10),
                AutoSize = true
            };

            // Criar Label para o horário
            Label labelHorario = new Label
            {
                Text = data, // Data de envio
                Font = new Font("Comic Sans MS", 10),
                Location = new Point(480, 10),
                AutoSize = true
            };

            // Criar Label para a mensagem
            Label labelMensagem = new Label
            {
                Text = mensagem,
                Font = new Font("Comic Sans MS", 10),
                Size = new Size(280, 20),
                Location = new Point(110, 50),
                AutoEllipsis = true
            };

            // Criar Label para o status de leitura
            Label labelLida = new Label
            {
                Text = lida ? "✓✓" : "✓",
                Font = new Font("Comic Sans MS", 10),
                Location = new Point(480, 140),
                AutoSize = true,
                ForeColor = lida ? Color.Green : Color.Gray
            };

            // Adicionar os controles ao Panel menor
            panelMensagem.Controls.Add(pictureBox);
            panelMensagem.Controls.Add(labelNome);
            panelMensagem.Controls.Add(labelHorario);
            panelMensagem.Controls.Add(labelMensagem);
            panelMensagem.Controls.Add(labelLida);

            // Adicionar o Panel menor ao Panel principal (panel1)
            panel1.Controls.Add(panelMensagem);

            // Ajustar posição dos Panels menores no panel1
            AtualizarPosicoesPanels();
        }

        private void AtualizarPosicoesPanels()
        {
            int yOffset = 10; // Espaçamento inicial do topo
            foreach (Control control in panel1.Controls)
            {
                if (control is Panel)
                {
                    control.Location = new Point(10, yOffset);
                    yOffset += control.Height + 10; // Espaçamento entre os Panels
                }
            }
        }


    }
}
