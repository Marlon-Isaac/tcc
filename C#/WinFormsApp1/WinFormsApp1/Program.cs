using System.Drawing;
using System;
using System.Drawing.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WinFormsApp1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Login());
            
        }
        
    }
    public class Banco()
    {
        public string tipo { get; set;}
        public string conexao = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TCC;Integrated Security=True;Connect Timeout=30;Encrypt=False";
        //public string conexao = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TCC;Integrated Security=True;Connect Timeout=30;Encrypt=False";
    }
    
    public class Sapae()
    {
        public string gmail = "sapae00001@gmail.com";
        public string senha = "rfld sbzi wpxa xczn";
    }

}