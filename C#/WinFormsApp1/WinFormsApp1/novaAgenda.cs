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
        string dia;
        public novaAgenda(string Dia)
        {
           dia = Dia;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0 || textBox1.Text == "")
            {
                MessageBox.Show("Preencha todos os itens!");
            }
            else
            {


                string horario = comboBox1.SelectedItem.ToString();
                if (horario == "Todos os horários preenchidos")
                {
                    MessageBox.Show("Todos os horários preenchidos tente marcar para outro dia");
                } else
                {
                    string compromisso = textBox1.Text;
                    try
                    {
                        Banco banco = new Banco();
                        using (SqlConnection conn = new SqlConnection(banco.conexao))
                        {
                            conn.Open();
                            using (SqlCommand command = new SqlCommand("SELECT COUNT(1) FROM Agenda WHERE Dia = @dia ", conn)) 
                            {
                                command.Parameters.AddWithValue("@dia", dia);
                                var result = command.ExecuteScalar();
                                if(result != null)
                                {
                                    using (SqlCommand cmd = new SqlCommand("UPDATE INTO Agenda SET " + horario + " = @compromisso"))
                                    {
                                        cmd.Parameters.AddWithValue("@compromisso", compromisso);
                                        cmd.ExecuteScalar();
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro: ", ex.Message);
                    }
                }
            }
        }

        private void novaAgenda_Load(object sender, EventArgs e)
        {
            try
            {
                Banco banco = new Banco();
                using (SqlConnection conn = new SqlConnection(banco.conexao))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Agenda WHERE Dia = @dia", conn))
                    {
                        cmd.Parameters.AddWithValue("@dia", dia);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                string seteHoras = reader["7:00"].ToString();
                                string seteMeia = reader["7:30"].ToString();
                                string oitoHoras = reader["8:00"].ToString();
                                string oitoMeia = reader["8:30"].ToString();
                                string noveHoras = reader["9:00"].ToString();
                                string noveMeia = reader["9:30"].ToString();
                                string dezHoras = reader["10:00"].ToString();
                                string dezMeia = reader["10:30"].ToString();
                                string onzeHoras = reader["11:00"].ToString();
                                string onzeMeia = reader["11:30"].ToString();
                                string trezeHoras = reader["13:00"].ToString();
                                string trezeMeia = reader["13:30"].ToString();
                                string quatorzeHoras = reader["14:00"].ToString();
                                string quatorzeMeia = reader["14:30"].ToString();
                                string quinzeHoras = reader["15:00"].ToString();
                                string quinzeMeia = reader["15:30"].ToString();
                                string dezesseisHoras = reader["16:00"].ToString();
                                string dezesseisMeia = reader["16:30"].ToString();
                                //------------------------------------------------//
                                //so para deixar melhor para ver//
                                //------------------------------------------------//

                                //fiz do jeito preguiçoso mesmo, pedi pro carlos fazer isso daqui, to afim de fazer mil ifs mas nem fudendo
                                //mesma coisa para as variaveis ali em cima
                                bool todosVazios = true;

                                if (!string.IsNullOrEmpty(seteHoras))
                                {
                                    comboBox1.Items.Add("7:00");
                                    todosVazios = false;
                                }

                                if (!string.IsNullOrEmpty(seteMeia))
                                {
                                    comboBox1.Items.Add("7:30");
                                    todosVazios = false;
                                }

                                if (!string.IsNullOrEmpty(oitoHoras))
                                {
                                    comboBox1.Items.Add("8:00");
                                    todosVazios = false;
                                }

                                if (!string.IsNullOrEmpty(oitoMeia))
                                {
                                    comboBox1.Items.Add("8:30");
                                    todosVazios = false;
                                }

                                if (!string.IsNullOrEmpty(noveHoras))
                                {
                                    comboBox1.Items.Add("9:00");
                                    todosVazios = false;
                                }

                                if (!string.IsNullOrEmpty(noveMeia))
                                {
                                    comboBox1.Items.Add("9:30");
                                    todosVazios = false;
                                }

                                if (!string.IsNullOrEmpty(dezHoras))
                                {
                                    comboBox1.Items.Add("10:00");
                                    todosVazios = false;
                                }

                                if (!string.IsNullOrEmpty(dezMeia))
                                {
                                    comboBox1.Items.Add("10:30");
                                    todosVazios = false;
                                }

                                if (!string.IsNullOrEmpty(onzeHoras))
                                {
                                    comboBox1.Items.Add("11:00");
                                    todosVazios = false;
                                }

                                if (!string.IsNullOrEmpty(onzeMeia))
                                {
                                    comboBox1.Items.Add("11:30");
                                    todosVazios = false;
                                }

                                if (!string.IsNullOrEmpty(trezeHoras))
                                {
                                    comboBox1.Items.Add("13:00");
                                    todosVazios = false;
                                }

                                if (!string.IsNullOrEmpty(trezeMeia))
                                {
                                    comboBox1.Items.Add("13:30");
                                    todosVazios = false;
                                }

                                if (!string.IsNullOrEmpty(quatorzeHoras))
                                {
                                    comboBox1.Items.Add("14:00");
                                    todosVazios = false;
                                }

                                if (!string.IsNullOrEmpty(quatorzeMeia))
                                {
                                    comboBox1.Items.Add("14:30");
                                    todosVazios = false;
                                }

                                if (!string.IsNullOrEmpty(quinzeHoras))
                                {
                                    comboBox1.Items.Add("15:00");
                                    todosVazios = false;
                                }

                                if (!string.IsNullOrEmpty(quinzeMeia))
                                {
                                    comboBox1.Items.Add("15:30");
                                    todosVazios = false;
                                }

                                if (!string.IsNullOrEmpty(dezesseisHoras))
                                {
                                    comboBox1.Items.Add("16:00");
                                    todosVazios = false;
                                }

                                if (!string.IsNullOrEmpty(dezesseisMeia))
                                {
                                    comboBox1.Items.Add("16:30");
                                    todosVazios = false;
                                }

                                // Verificação final: Se todas as variáveis estiverem vazias
                                if (todosVazios)
                                {
                                    comboBox1.Items.Add("Todos os horários preenchidos");
                                }


                            }
                        }
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Erro: ", ex.Message);
            }
        }
    }
}
