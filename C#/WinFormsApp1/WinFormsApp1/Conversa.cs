using System;
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
    public partial class Conversa : Form
    {
        private int remetenteId;
        private int? chatId;
        private int destinatarioId;
        private System.Windows.Forms.Timer timer;

        FlowLayoutPanel mensagensPanel = new FlowLayoutPanel
        {
            Name = "mensagensPanel",
            Dock = DockStyle.Fill, // Preenche o formulário
            AutoScroll = true,    // Ativa a barra de rolagem para mensagens longas
            FlowDirection = FlowDirection.TopDown, // Organiza mensagens de cima para baixo
            WrapContents = false  // Mantém mensagens em uma única linha (sem quebra lateral)
        };

        public Conversa(int remetenteId, int? chatId, int destinatarioId)
        {
            InitializeComponent();

            this.remetenteId = remetenteId;
            this.chatId = chatId;
            this.destinatarioId = destinatarioId;

            // Inicializa o painel de mensagens

            // Inicializa o TextBox de envio
            TextBox mensagemTextBox = new TextBox
            {
                Dock = DockStyle.Bottom,
                Multiline = true,
                Height = 60,
                Width = 360
            };

            // Inicializa o botão de envio
            Button enviarButton = new Button
            {
                Text = "Enviar",
                Dock = DockStyle.Bottom,
                Height = 40,
                BackColor = Color.LightBlue
            };

            enviarButton.Click += (s, e) =>
            {
                string mensagem = mensagemTextBox.Text.Trim();
                if (!string.IsNullOrEmpty(mensagem))
                {
                    if (chatId == null)
                    {
                        CriarNovaConversa(mensagem);
                    }
                    else
                    {
                        EnviarMensagem(chatId.Value, mensagem);
                    }
                    mensagemTextBox.Clear();
                }
            };
            FlowLayoutPanel mensagensPanel = new FlowLayoutPanel
            {
                Name = "mensagensPanel",
                Dock = DockStyle.Fill, // Preenche o formulário
                AutoScroll = true,    // Ativa a barra de rolagem para mensagens longas
                FlowDirection = FlowDirection.TopDown, // Organiza mensagens de cima para baixo
                WrapContents = false  // Mantém mensagens em uma única linha (sem quebra lateral)
            };

            // Adiciona o painel ao formulário
            this.Controls.Add(mensagensPanel);
            Controls.Add(mensagemTextBox);
            Controls.Add(enviarButton);

            // Decide qual função chamar
            if (chatId == null)
            {
                CriarNovaConversa(null);
            }
            else
            {
                CarregarConversa();
            }
        }
        private void Conversa_Load(object sender, EventArgs e)
        {

        }
        private void CriarNovaConversa(string mensagemInicial)
        {
            using (SqlConnection conn = new SqlConnection("SuaConnectionStringAqui"))
            {
                conn.Open();

                // Cria um novo registro na tabela Chat
                SqlCommand criarChatCmd = new SqlCommand(
                    "INSERT INTO Chat (UsuarioRemetenteID, UsuarioDestinatarioID, DataEnvio, Lida) OUTPUT INSERTED.Id VALUES (@remetente, @destinatario, GETDATE(), 0)",
                    conn
                );
                criarChatCmd.Parameters.AddWithValue("@remetente", remetenteId);
                criarChatCmd.Parameters.AddWithValue("@destinatario", destinatarioId);

                chatId = (int)criarChatCmd.ExecuteScalar();

                if (!string.IsNullOrEmpty(mensagemInicial))
                {
                    EnviarMensagem(chatId.Value, mensagemInicial);
                }
            }

            CarregarConversa();
        }

        private void EnviarMensagem(int chatId, string mensagem)
        {
            using (SqlConnection conn = new SqlConnection("SuaConnectionStringAqui"))
            {
                conn.Open();

                // Insere a mensagem no banco
                SqlCommand enviarMensagemCmd = new SqlCommand(
                    "INSERT INTO Mensagens (ChatId, Mensagem, DataEnvio, IdRemetente, Lida) VALUES (@chatId, @mensagem, GETDATE(), @remetenteId, 0)",
                    conn
                );
                enviarMensagemCmd.Parameters.AddWithValue("@chatId", chatId);
                enviarMensagemCmd.Parameters.AddWithValue("@mensagem", mensagem);
                enviarMensagemCmd.Parameters.AddWithValue("@remetenteId", remetenteId);

                enviarMensagemCmd.ExecuteNonQuery();
            }
        }

        private void CarregarConversa()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 100;
            timer.Tick += (s, args) => 

            {
                using (SqlConnection conn = new SqlConnection("SuaConnectionStringAqui"))
                {
                    conn.Open();

                    // Busca todas as mensagens do Chat
                    SqlCommand carregarCmd = new SqlCommand(
                        "SELECT Mensagem, DataEnvio, Lida, IdRemetente FROM Mensagens WHERE ChatId = @chatId ORDER BY DataEnvio ASC",
                        conn
                    );
                    carregarCmd.Parameters.AddWithValue("@chatId", chatId);

                    SqlDataReader reader = carregarCmd.ExecuteReader();
                    mensagensPanel.Controls.Clear(); // Remove mensagens antigas para evitar duplicação.

                    while (reader.Read())
                    {
                        CriarMensagemPanel(
                            reader["Mensagem"].ToString(),
                            (DateTime)reader["DataEnvio"],
                            (bool)reader["Lida"],
                            (int)reader["IdRemetente"]
                        );
                    }
                }
            };

            timer.Start();
        }

        private void CriarMensagemPanel(string mensagem, DateTime dataEnvio, bool lida, int idRemetente)
        {
            // Define cor e posição baseadas no remetente
            bool ehUsuarioLogado = idRemetente == SessaoUsuario.UsuarioLogadoId;
            Color corPanel = ehUsuarioLogado ? ColorTranslator.FromHtml("#045c4c") : Color.LightGray;

            Panel mensagemPanel = new Panel
            {
                BackColor = corPanel,
                Width = 330,
                AutoSize = true,
                Padding = new Padding(10),
                Margin = new Padding(10),
                Anchor = ehUsuarioLogado ? AnchorStyles.Right : AnchorStyles.Left
            };

            Label mensagemLabel = new Label
            {
                Text = mensagem,
                AutoSize = true,
                ForeColor = Color.White
            };

            Label statusLabel = new Label
            {
                Text = lida ? "Lido" : "Não lido",
                Font = new Font("Arial", 9),
                ForeColor = Color.White,
                Dock = DockStyle.Bottom
            };

            mensagemPanel.Controls.Add(mensagemLabel);
            mensagemPanel.Controls.Add(statusLabel);
            mensagensPanel.Controls.Add(mensagemPanel);
        }
    }
}

