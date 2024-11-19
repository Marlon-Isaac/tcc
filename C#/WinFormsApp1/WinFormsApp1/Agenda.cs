using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Agenda : Form
    {
        public Agenda()
        {
            InitializeComponent();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            tipo2 tipo2 = new tipo2();
            string a = tipo2.Tipoo();
            if(a == "Secretaria")
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
            string dia = date.Day.ToString();//tratando a variavel date para apenas salvar o dia 
            Mes mes1 = new Mes();
            string mes = mes1.mes(date.Month);
            panel2.Visible = true;
            labelDia.Text = "Eventos agendados do dia " + dia;
            labelMes.Text = "de " + mes;
            label1.Text = "Sem eventos agendados para este dia";
            label1.TextAlign = ContentAlignment.TopCenter;
            Banco banco = new Banco();
            using (SqlConnection Conn = new SqlConnection(banco.conexao))
            {
                Conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Agenda WHERE Dia=@dia AND Horario=@hora ", Conn))
                {
                    cmd.Parameters.AddWithValue("@dia", date);
                    cmd.Parameters.AddWithValue("@hora", "9:30");
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count > 0)
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                hora = Convert.ToInt32(reader["Hora"]);//.ToString();
                                compromisso.Add(reader["Compromisso"].ToString());
                            }
                        }
                        label1.Text = string.Join(Environment.NewLine, compromisso);
                    }
                }
            }
        }

        private void Agenda_Load(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }
    }
}
