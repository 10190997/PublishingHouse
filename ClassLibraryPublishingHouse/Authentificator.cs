using PublishingHouse;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibraryPublishingHouse
{
    public class Authentificator
    {
        public static bool Register(string email, string password, string login, string lastName, string firstName)
        {
            List<User> users = DB.db.Users.ToList();
            foreach (User u in users)
            {
                if (email == u.EmailAddress || login == u.Login)
                {
                    return false;
                }
            }
            User user = new User
            {
                EmailAddress = email,
                Login = login,
                FirstName = firstName,
                LastName = lastName,
                Salt = login,
                Password = SecurityHelper.HashPassword(password, login, 10101, 70)
            };
            DB.db.Users.Add(user);
            DB.db.SaveChanges();
            return true;
        }

        public static string Authorize(string login, string password, User user)
        {
            List<User> users = DB.db.Users.ToList();
            user = users.SingleOrDefault(x => x.Login == login);
            var Password = SecurityHelper.HashPassword(password, login, 10101, 70);
            return user != null && user.Password == Password
                ? "OK" : user == null ? "User not found" : user.Password != Password ? "Incorrect password" : null;
        }
    }
}