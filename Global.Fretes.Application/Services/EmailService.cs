using Global.Fretes.Application.Dtos.Emails;
using Global.Fretes.Application.Interfaces;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using Global.Fretes.Application.Configuracoes;

namespace Global.Fretes.Application.Services;

public sealed class EmailService : IEmailService
{
    public async Task<bool> EnviarAsync(EnvioEmailDto envioEmailDto)
    {
		try
		{
            var mail = new MailMessage(ConfiguracaoSmtpEmail.From, envioEmailDto.Para)
            {
                Subject = envioEmailDto.Assunto,
                SubjectEncoding = System.Text.Encoding.GetEncoding("UTF-8"),
                BodyEncoding = System.Text.Encoding.GetEncoding("UTF-8"),
                Body = envioEmailDto.Mensagem
            };

            if (!string.IsNullOrWhiteSpace(envioEmailDto.Html))
            {
                mail.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(envioEmailDto.Html, null, MediaTypeNames.Text.Html));
            }

            var smtp = new SmtpClient(ConfiguracaoSmtpEmail.Servidor, int.Parse(ConfiguracaoSmtpEmail.Porta))
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(ConfiguracaoSmtpEmail.From, ConfiguracaoSmtpEmail.Senha)
            };
            await smtp.SendMailAsync(mail);
            return true;
        }
		catch (Exception ex)
		{
            Console.WriteLine(ex.Message);
            return false;
		}
    }
}
