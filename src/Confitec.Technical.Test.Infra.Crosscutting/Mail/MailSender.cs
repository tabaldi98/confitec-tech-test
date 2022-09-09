using SendGrid;
using SendGrid.Helpers.Mail;

namespace Confitec.Technical.Test.Infra.Crosscutting.Mail
{
    public interface IMailSender
    {
        Task<bool> SendRecoveryPasswordAsync(string email, string fullName, string code);
    }

    public class MailSender : IMailSender
    {
        public async Task<bool> SendRecoveryPasswordAsync(string email, string fullName, string code)
        {
            var msg = MailHelper.CreateSingleEmail(new EmailAddress("tabaldi98@gmail.com", "Anderson Tabaldi")
                         , new EmailAddress("andersonandi_t@hotmail.com", fullName)
                         , "Recuperação de senha"
                         , TextTemplate(fullName, code)
                         , HtmlTemplate(fullName, code));

            var client = new SendGridClient("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");
            var response = await client.SendEmailAsync(msg);

            return response.IsSuccessStatusCode;
        }

        private string HtmlTemplate(string fullName, string code)
        {
            return @$"
                    <p>Olá <strong>{fullName}.</strong></p>
                    <p>Informe o código <strong>{code}</strong> para recuperar sua senha.</p>";
        }

        private string TextTemplate(string fullName, string code)
        {
            return @$"
                    Olá {fullName}.
                    Informe o código {code} para recuperar sua senha.";
        }
    }
}
