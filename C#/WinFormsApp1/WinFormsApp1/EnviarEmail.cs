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

        Sapae sapae = new();
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
            var mail = new MailMessage
            {
                From = new MailAddress(sapae.gmail),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };
            mail.To.Add(email);

            return mail;

        }

        private void Smtp(MailMessage message)
        {
            SmtpClient smtpClient = new()
            {
                Host = Provedor,
                Port = 587,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(Usuario, Senha)
            };
            smtpClient.Send(message);
            smtpClient.Dispose();


        }

    }
}
