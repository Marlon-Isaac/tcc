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
            if (comboBox1.SelectedIndex == -1 || textBox1.Text == "" || comboBox1.SelectedItem == null)
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
                        string hora ="";
                        hora = horario switch
                        {
                            "7:00" => "SeteHoras",
                            "7:30" => "SeteMeia",
                            "8:00" => "OitoHoras",
                            "8:30" => "OitoMeia",
                            "9:00" => "NoveHoras",
                            "9:30" => "NoveMeia",
                            "10:00" => "DezHoras",
                            "10:30" => "DezMeia",
                            "11:00" => "OnzeHoras",
                            "11:30" => "OnzeMeia",
                            "13:00" => "TrezeHoras",
                            "13:30" => "TrezeMeia",
                            "14:00" => "QuatorzeHoras",
                            "14:30" => "QuatorzeMeia",
                            "15:00" => "QuinzeHoras",
                            "15:30" => "QuinzeMeia",
                            "16:00" => "DezesseisHoras",
                            "16:30" => "DezesseisMeia",
                            _ => "Horário desconhecido",// Caso o horário não seja encontrado
                        };
                        Banco banco = new Banco();
                        using (SqlConnection conn = new SqlConnection(banco.conexao))
                        {
                            
                            conn.Open();
                            using (SqlCommand command = new SqlCommand("SELECT COUNT(1) FROM Agenda WHERE Dia = @dia ", conn)) 
                            {
                                command.Parameters.AddWithValue("@dia", dia);
                                int result = Convert.ToInt32(command.ExecuteScalar());
                                if(result != 0)
                                {
                                    MessageBox.Show("a");
                                    using (SqlCommand cmd = new SqlCommand($"UPDATE Agenda SET {hora} = @compromisso WHERE Dia = @dia ", conn))
                                    {
                                        cmd.Parameters.AddWithValue("@dia", dia);
                                        cmd.Parameters.AddWithValue("@compromisso", compromisso);
                                        cmd.ExecuteScalar();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(horario);
                                    string query = $"INSERT INTO Agenda (Dia, {hora}) VALUES (@dia, @hora)";

                                    using (SqlCommand cmd = new SqlCommand(query, conn))
                                    {
                                        cmd.Parameters.AddWithValue("@dia", dia);
                                        cmd.Parameters.AddWithValue("@hora", horario);
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro: " + ex.Message);
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
                            if (reader.Read())
                            {
                                string seteHoras = reader["SeteHoras"].ToString(); // "Sete horas da manhã"
                                string seteMeia = reader["SeteMeia"].ToString(); // "Sete e meia da manhã"
                                string oitoHoras = reader["OitoHoras"].ToString(); // "Oito horas da manhã"
                                string oitoMeia = reader["OitoMeia"].ToString(); // "Oito e meia da manhã"
                                string noveHoras = reader["NoveHoras"].ToString(); // "Nove horas da manhã"
                                string noveMeia = reader["NoveMeia"].ToString(); // "Nove e meia da manhã"
                                string dezHoras = reader["DezHoras"].ToString(); // "Dez horas da manhã"
                                string dezMeia = reader["DezMeia"].ToString(); // "Dez e meia da manhã"
                                string onzeHoras = reader["OnzeHoras"].ToString(); // "Onze horas da manhã"
                                string onzeMeia = reader["OnzeMeia"].ToString(); // "Onze e meia da manhã"
                                string trezeHoras = reader["TrezeHoras"].ToString(); // "Treze horas"
                                string trezeMeia = reader["TrezeMeia"].ToString(); // "Treze e meia"
                                string quatorzeHoras = reader["QuatorzeHoras"].ToString(); // "Quatorze horas"
                                string quatorzeMeia = reader["QuatorzeMeia"].ToString(); // "Quatorze e meia"
                                string quinzeHoras = reader["QuinzeHoras"].ToString(); // "Quinze horas"
                                string quinzeMeia = reader["QuinzeMeia"].ToString(); // "Quinze e meia"
                                string dezesseisHoras = reader["DezesseisHoras"].ToString(); // "Dezesseis horas"
                                string dezesseisMeia = reader["DezesseisMeia"].ToString(); // "Dezesseis e meia"
                                //------------------------------------------------//
                                //so para deixar melhor para ver//
                                //------------------------------------------------//

                                //fiz do jeito preguiçoso mesmo, pedi pro carlos fazer isso daqui, to afim de fazer mil ifs mas nem fudendo
                                //mesma coisa para as variaveis ali em cima
                                bool todosVazios = true;
                                List<string> lista = new List<string>();
                                MessageBox.Show("essa logica ta certa");

                                if (string.IsNullOrEmpty(seteHoras))
                                {
                                    lista.Add("7:00");

                                    todosVazios = false;
                                }

                                if (string.IsNullOrEmpty(seteMeia))
                                {
                                    comboBox1.Items.Add("7:30");
                                    todosVazios = false;
                                }

                                if (string.IsNullOrEmpty(oitoHoras))
                                {
                                    comboBox1.Items.Add("8:00");
                                    todosVazios = false;
                                }

                                if (string.IsNullOrEmpty(oitoMeia))
                                {
                                    comboBox1.Items.Add("8:30");
                                    todosVazios = false;
                                }

                                if (string.IsNullOrEmpty(noveHoras))
                                {
                                    comboBox1.Items.Add("9:00");
                                    todosVazios = false;
                                }

                                if (string.IsNullOrEmpty(noveMeia))
                                {
                                    comboBox1.Items.Add("9:30");
                                    todosVazios = false;
                                }

                                if (string.IsNullOrEmpty(dezHoras))
                                {
                                    comboBox1.Items.Add("10:00");
                                    todosVazios = false;
                                }

                                if (string.IsNullOrEmpty(dezMeia))
                                {
                                    comboBox1.Items.Add("10:30");
                                    todosVazios = false;
                                }

                                if (string.IsNullOrEmpty(onzeHoras))
                                {  
                                    comboBox1.Items.Add("11:00");
                                    todosVazios = false;
                                }

                                if (string.IsNullOrEmpty(onzeMeia))
                                {
                                    comboBox1.Items.Add("11:30");
                                    todosVazios = false;
                                }

                                if (string.IsNullOrEmpty(trezeHoras))
                                {
                                    comboBox1.Items.Add("13:00");
                                    todosVazios = false;
                                }

                                if (string.IsNullOrEmpty(trezeMeia))
                                {
                                    comboBox1.Items.Add("13:30");
                                    todosVazios = false;
                                }

                                if (string.IsNullOrEmpty(quatorzeHoras))
                                {
                                    comboBox1.Items.Add("14:00");
                                    todosVazios = false;
                                }

                                if (string.IsNullOrEmpty(quatorzeMeia))
                                {
                                    comboBox1.Items.Add("14:30");
                                    todosVazios = false;
                                }

                                if (string.IsNullOrEmpty(quinzeHoras))
                                {
                                    comboBox1.Items.Add("15:00");
                                    todosVazios = false;
                                }

                                if (string.IsNullOrEmpty(quinzeMeia))
                                {
                                    comboBox1.Items.Add("15:30");
                                    todosVazios = false;
                                }

                                if (string.IsNullOrEmpty(dezesseisHoras))
                                {
                                    comboBox1.Items.Add("16:00");
                                    todosVazios = false;
                                }

                                if (string.IsNullOrEmpty(dezesseisMeia))
                                {
                                    comboBox1.Items.Add("16:30");
                                    todosVazios = false;
                                }

                                // Verificação final: Se todas as variáveis estiverem vazias
                                if (todosVazios)
                                {
                                    comboBox1.Items.Add("Todos os horários preenchidos");
                                }
                                comboBox1.Items.AddRange(lista.ToArray());

                            }
                            else
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
