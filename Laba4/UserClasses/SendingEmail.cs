using System;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Laba4.UserClasses
{
    public class SendingEmail
    {
        public InfoEmailSending InfoEmailSending { get; private set; }

        public SendingEmail(InfoEmailSending infoEmailSending)
        {
            InfoEmailSending = infoEmailSending ?? throw new ArgumentNullException(nameof(infoEmailSending));
        }

        public void Send()
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient(InfoEmailSending.SmtpClientAddress);
                smtpClient.UseDefaultCredentials = true;
                smtpClient.EnableSsl = true;

                NetworkCredential basicAuthentificationInfo =
                    new NetworkCredential(InfoEmailSending.EmailAddressFrom.EmailAddress, InfoEmailSending.EmailPassword);

                smtpClient.Credentials = basicAuthentificationInfo;

                MailAddress from = new MailAddress(InfoEmailSending.EmailAddressFrom.EmailAddress, InfoEmailSending.EmailAddressFrom.Name);

                MailAddress to = new MailAddress(InfoEmailSending.EmailAddressTo.EmailAddress, InfoEmailSending.EmailAddressTo.Name);

                MailMessage myMail = new MailMessage(from, to);

                MailAddress replyTo = new MailAddress(InfoEmailSending.EmailAddressFrom.EmailAddress);
                myMail.ReplyToList.Add(replyTo);

                Encoding encoding = Encoding.UTF8;

                myMail.Subject = InfoEmailSending.Subject;
                myMail.SubjectEncoding = encoding;

                myMail.Body = InfoEmailSending.Body;
                myMail.BodyEncoding = encoding;

                smtpClient.Send(myMail);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
