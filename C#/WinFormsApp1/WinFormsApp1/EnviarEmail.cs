using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class EnviarEmail
    {


        public string Provedor { get; private set; }

        public string Usuario { get; private set; }

        public string Senha { get; set; }

        Sapae sapae = new Sapae();
        public EnviarEmail(string provedor, string usuario, string senha)
        {
            Provedor = provedor ?? throw new ArgumentNullException(nameof(provedor));
            Usuario = usuario ?? throw new ArgumentNullException(nameof(usuario));
            Senha = senha ?? throw new ArgumentNullException(nameof(senha));
        }

        public void Enviar(string email, string subject, string body)
        {
            var mensagem = PrepararMensagem(email, subject, body);

            Smtp(mensagem);
        }


        private MailMessage PrepararMensagem(string email, string subject, string body)
        {
            var mail = new MailMessage();
            mail.From = new MailAddress(sapae.gmail);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            mail.To.Add(email);

            return mail;

        }

        private void Smtp(MailMessage message)
        {
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = Provedor;
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.Timeout = 50000;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(Usuario, Senha);
            smtpClient.Send(message);
            smtpClient.Dispose();


        }

    }
}
