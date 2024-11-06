using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            DateTime date = ((MonthCalendar)sender).SelectionStart;//Guardar o dia selecionado em uma variavel
            string dia = date.Day.ToString();//tratando a variavel date para apenas salvar o dia 
            Mes mes1 = new Mes();
            string mes = mes1.mes(date.Month);
            panel2.Visible = true;
            labelDia.Text = "Eventos agendados do dia " + dia;
            labelMes.Text = "de "+ mes;
            label1.Text = "Sem eventos agendados para este dia";
            label1.TextAlign = ContentAlignment.TopCenter;


        }
    }
}
