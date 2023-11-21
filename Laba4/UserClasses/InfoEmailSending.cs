using System;

namespace Laba4.UserClasses
{
    public class InfoEmailSending
    {
        public InfoEmailSending(string smtpClientAddress,  StringPair emailAddressFrom,  string emailPassword, 
            StringPair emailAddressTo, 
            string subject, string body)
        {
            SmtpClientAddress = string.IsNullOrWhiteSpace(smtpClientAddress) ? throw new Exception(errorMessage)
                : smtpClientAddress;

            EmailPassword = string.IsNullOrWhiteSpace(emailPassword) ? throw new Exception(errorMessage)
                : emailPassword;

            EmailAddressFrom = emailAddressFrom ?? throw new ArgumentNullException(nameof(emailAddressFrom));
            EmailAddressTo = emailAddressTo ?? throw new ArgumentNullException(nameof(emailAddressTo));
            Subject = subject ?? throw new ArgumentNullException(nameof(subject));
            Body = body ?? throw new ArgumentNullException(nameof(body));
        }

        private string errorMessage = "Нельзя вставлять пробелы или пустое значение!";

        public string SmtpClientAddress { get; set; }

        public StringPair EmailAddressFrom { get; set; }
        
        public string EmailPassword { get; set; }
        
        public StringPair EmailAddressTo { get; set; }
        
        public string Subject { get; set; }

        public string Body { get; set; }
    }
}