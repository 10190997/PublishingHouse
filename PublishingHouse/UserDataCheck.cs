using System.Net.Mail;

namespace PublishingHouse
{
    public class UserDataCheck
    {
        /// <summary>
        /// Сhecks if the entered string is an email
        /// </summary>
        public static bool CheckEmail(string email)
        {
            try
            {
                MailAddress addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Сhecks if the entered string has at least one uppercase letter
        /// </summary>
        public static bool HasUpper(string password)
        {
            foreach (char c in password)
            {
                if (char.IsLetter(c) && char.IsUpper(c))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Сhecks if the entered string has at least one digit
        /// </summary>
        public static bool HasDigit(string password)
        {
            foreach (char c in password)
            {
                if (char.IsDigit(c))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Сhecks if the entered string has at least one special character
        /// </summary>
        public static bool HasSpecialCharacter(string password)
        {
            foreach (char c in password)
            {
                if (c.Equals('!') ||
                    c.Equals('@') ||
                    c.Equals('#') ||
                    c.Equals('$') ||
                    c.Equals('%') ||
                    c.Equals('^'))
                {
                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// Сhecks if the entered string is 6 or more characters long
        /// </summary>
        public static bool IsLong(string password)
        {
            int count = 0;
            foreach (char c in password)
            {
                count++;
            }

            return count >= 6;
        }
        /// <summary>
        /// Сhecks if the entered string is a strong password
        /// </summary>
        public static bool IsStrong(string password)
        {
            return IsLong(password) &&
                HasUpper(password) &&
                HasDigit(password) &&
                HasSpecialCharacter(password);
        }
    }
}
