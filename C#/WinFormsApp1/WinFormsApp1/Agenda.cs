using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WinFormsApp1
{
    public partial class Agenda : Form
    {
        string dia;
        string mes;
        DateTime data;
        public Agenda()
        {
            InitializeComponent();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

            string a = SessaoUsuario.TipoUsuario;
            if (a == "Secretaria")
            {
                button10.Visible = true;
            }
            else
            {
                button10.Visible = false;
            }
            int hora;
            List<string> compromisso = new List<string>();

            DateTime date = ((MonthCalendar)sender).SelectionStart;//Guardar o dia selecionado em uma variavel
            dia = date.Day.ToString();//tratando a variavel date para apenas salvar o dia 
            Mes mes1 = new Mes();
            mes = mes1.mes(date.Month);
            data = date.Date;
            panel2.Visible = true;
            labelDia.Text = "Eventos agendados do dia " + dia;
            labelMes.Text = "de " + mes;
            label1.Text = "Sem eventos agendados para este dia";
            label1.TextAlign = ContentAlignment.TopCenter;
            List<Sim> sim = CarregarBanco();
            Exibir(sim);
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += (s, ev) =>
            {
                List<Sim> sim = CarregarBanco();
                Exibir(sim);
            };
        }

        private List<Sim> CarregarBanco()
        {
            List<Sim> dados = new();
            Banco banco = new Banco();
            using (SqlConnection Conn = new SqlConnection(banco.conexao))
            {
                Conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Agenda WHERE Dia=@dia", Conn))
                {
                    cmd.Parameters.AddWithValue("@dia", dia + '/' + mes);
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var sim = new Sim
                            {
                                horario = reader["Horario"].ToString(),
                                compromisso = reader["Compromisso"].ToString()
                            };
                            dados.Add(sim);
                        }
                    }
                }
            }
            return dados;
        }
        private void Exibir(List<Sim> lista)
        {
            List<string> a = new();
            foreach (Sim sim in lista)
            {
                if (sim.horario == "7:00")
                {
                    a.Add(sim.horario + ": " +  sim.compromisso + "\n") ;
                }
                if (sim.horario == "7:30")
                {
                    a.Add(sim.horario + ": " + sim.compromisso + "\n");
                }
                if (sim.horario == "8:00")
                {
                    a.Add(sim.horario + ": " + sim.compromisso + "\n");
                }
                if (sim.horario == "8:30")
                {
                    a.Add(sim.horario + ": " + sim.compromisso + "\n");
                }
                if (sim.horario == "9:00")
                {
                    a.Add(sim.horario + ": " + sim.compromisso + "\n");
                }
                if (sim.horario == "9:30")
                {
                    a.Add(sim.horario + ": " + sim.compromisso + "\n");
                }
                if (sim.horario == "10:00")
                {
                    a.Add(sim.horario + ": " + sim.compromisso + "\n");
                }
                if (sim.horario == "10:30")
                {
                    a.Add(sim.horario + ": " + sim.compromisso + "\n");
                }
                if (sim.horario == "11:00")
                {
                    a.Add(sim.horario + ": " + sim.compromisso + "\n");
                }
                if (sim.horario == "11:30")
                {
                    a.Add(sim.horario + ": " + sim.compromisso + "\n");
                }
                if (sim.horario == "13:00")
                {
                    a.Add(sim.horario + ": " + sim.compromisso + "\n");
                }
                if (sim.horario == "13:30")
                {
                    a.Add(sim.horario + ": " + sim.compromisso + "\n");
                }
                if (sim.horario == "14:00")
                {
                    a.Add(sim.horario + ": " + sim.compromisso + "\n");
                }
                if (sim.horario == "14:30")
                {
                    a.Add(sim.horario + ": " + sim.compromisso + "\n");
                }
                if (sim.horario == "15:00")
                {
                    a.Add(sim.horario + ": " + sim.compromisso + "\n");
                }
                if (sim.horario == "15:30")
                {
                    a.Add(sim.horario + ": " + sim.compromisso + "\n");
                }
                if (sim.horario == "16:00")
                {
                    a.Add(sim.horario + ": " + sim.compromisso + "\n");
                }
                if (sim.horario == "16:30")
                {
                    a.Add(sim.horario + ": " + sim.compromisso + "\n");
                }
                if (a != null)
                {
                    label1.Text = string.Join("", a);
                }
                else { label1.Text = "Sem compromissos para esta data";  }
            }
        }

        private void Agenda_Load(object sender, EventArgs e)
        {
            string a = tipo.TipoUsuario;
            if (a == "Secretaria")
            {
                panelGeral.Visible = false;
                panelSecretaria.Visible = true;
            }
            else
            {
                panelGeral.Visible = true;
                panelSecretaria.Visible = false;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            novaAgenda novaAgenda = new novaAgenda(dia, mes, data);
            novaAgenda.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home homeForm = new();
            homeForm.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Perfil perfil = new Perfil();
            perfil.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DicasPost dicasPostForm = new();
            dicasPostForm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Agenda agenda1 = new Agenda();
            agenda1.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Close();
        }

        private void button6_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelSecretaria_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
