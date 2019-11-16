using System.Collections.Generic;
using Guards;
using Kledex.Domain;

namespace MyLunch.Domain.Shared
{
    public class EmailAddress : ValueObject
    {
        public string Value { get; private set; }

        public EmailAddress(string value)
        {
            Guard.ArgumentCondition(() => value, email => IsValidEmail(email));

            Value = value;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
