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
    public partial class novaAgenda : Form
    {
        DateTime data;
        string mes;
        string dia;
        public novaAgenda(string Dia, string Mes, DateTime Data)
        {
            mes = Mes;
           dia = Dia;
            data = Data;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1 || textBox1.Text == "" || comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Preencha todos os itens!");
            }
            else
            {
                string horario = comboBox1.SelectedItem.ToString();
                string compromisso = textBox1.Text;

                try
                {
                    Banco banco = new Banco();
                    using (SqlConnection conn = new SqlConnection(banco.conexao))
                    {
                        conn.Open();

                        string query = "INSERT INTO Agenda (Dia, Horario, Compromisso) VALUES (@dia, @hora, @Compromisso)";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@dia", dia + '/' + mes);
                            cmd.Parameters.AddWithValue("@hora", horario);
                            cmd.Parameters.AddWithValue("@Compromisso", compromisso);
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO notificacoes (notificacao, data, Usuario) VALUES (@nota, @dia, @tipo)", conn))
                        {
                            cmd.Parameters.AddWithValue("@nota", "Novo compromisso para o dia "+ data.Date.ToString() +": " + compromisso);
                            cmd.Parameters.AddWithValue("@dia", DateTime.Now.Date);
                            cmd.Parameters.AddWithValue("@tipo", "Geral");
                            cmd.ExecuteNonQuery();

                        }
                    }
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }
        }

        private void novaAgenda_Load(object sender, EventArgs e)
        {
            try
            {
                List<string> lista = new List<string>
                {
                    "7:00",
                    "7:30",
                    "8:00",
                    "8:30",
                    "9:00",
                    "9:30",
                    "10:00",
                    "10:30",
                    "11:00",
                    "11:30",
                    "13:00",
                    "13:30",
                    "14:00",
                    "14:30",
                    "15:00",
                    "15:30",
                    "16:00",
                    "16:30"
                };

                comboBox1.Items.AddRange(lista.ToArray());

                Banco banco = new Banco();
                using (SqlConnection conn = new SqlConnection(banco.conexao))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Agenda WHERE Dia = @dia", conn))
                    {
                        
                        cmd.Parameters.AddWithValue("@dia", dia+'/'+mes);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            DateTime horarioInicial = DateTime.Parse("7:00");
                            DateTime horarioFinal = DateTime.Parse("16:30");
                            if (reader.Read())
                            {

                                if (reader["Horario"].ToString() == "7:00")
                                {
                                    comboBox1.Items.Remove("7:00");
                                }
                                if (reader["Horario"].ToString() == "7:30")
                                {
                                    comboBox1.Items.Remove("7:30");
                                }
                                if (reader["Horario"].ToString() == "8:00")
                                {
                                    comboBox1.Items.Remove("8:00");
                                }
                                if (reader["Horario"].ToString() == "8:30")
                                {
                                    comboBox1.Items.Remove("8:30");
                                }
                                if (reader["Horario"].ToString() == "9:00")
                                {
                                    comboBox1.Items.Remove("9:00");
                                }
                                if (reader["Horario"].ToString() == "9:30")
                                {
                                    comboBox1.Items.Remove("9:30");
                                }
                                if (reader["Horario"].ToString() == "10:00")
                                {
                                    comboBox1.Items.Remove("10:00");
                                }
                                if (reader["Horario"].ToString() == "10:30")
                                {
                                    comboBox1.Items.Remove("10:30");
                                }
                                if (reader["Horario"].ToString() == "11:00")
                                {
                                    comboBox1.Items.Remove("11:00");
                                }
                                if (reader["Horario"].ToString() == "11:30")
                                {
                                    comboBox1.Items.Remove("11:30");
                                }
                                if (reader["Horario"].ToString() == "12:00")
                                {
                                    comboBox1.Items.Remove("12:00");
                                }
                                if (reader["Horario"].ToString() == "12:30")
                                {
                                    comboBox1.Items.Remove("12:30");
                                }
                                if (reader["Horario"].ToString() == "13:00")
                                {
                                    comboBox1.Items.Remove("13:00");
                                }
                                if (reader["Horario"].ToString() == "13:30")
                                {
                                    comboBox1.Items.Remove("13:30");
                                }
                                if (reader["Horario"].ToString() == "14:00")
                                {
                                    comboBox1.Items.Remove("14:00");
                                }
                                if (reader["Horario"].ToString() == "14:30")
                                {
                                    comboBox1.Items.Remove("14:30");
                                }
                                if (reader["Horario"].ToString() == "15:00")
                                {
                                    comboBox1.Items.Remove("15:00");
                                }
                                if (reader["Horario"].ToString() == "15:30")
                                {
                                    comboBox1.Items.Remove("15:30");
                                }
                                if (reader["Horario"].ToString() == "16:00")
                                {
                                    comboBox1.Items.Remove("16:00");
                                }
                                if (reader["Horario"].ToString() == "16:30")
                                {
                                    comboBox1.Items.Remove("16:30");
                                }
                            }
                        }
                    }
                    if(comboBox1.Items.Count <= 0)
                    {
                        DialogResult result = MessageBox.Show("Todos os horários preenchidos tente marcar para outro dia", "Lotado", MessageBoxButtons.OK);
                        if (result == DialogResult.OK)
                        {
                            this.Close();
                        }
                    }
                }
            }catch(Exception ex)
            {
                DialogResult result = MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    this.Close();
                }
            }
        }
    }
}
