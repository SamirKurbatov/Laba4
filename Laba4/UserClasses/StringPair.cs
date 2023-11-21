using System;

namespace Laba4.UserClasses
{
    public class StringPair
    {
        public StringPair(string emailAddress, string name)
        {
            if (string.IsNullOrWhiteSpace(emailAddress)) throw new ArgumentException(nameof(emailAddress));
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(nameof(name));

            EmailAddress = emailAddress;
            Name = name;
        }

        public string EmailAddress { get; set; }

        public string Name { get; set; }
    }
}
