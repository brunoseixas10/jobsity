using ChatApp.Entity;
using System.Collections.Concurrent;

namespace ChatApp.Api
{
    //this will be the in-memory database for the app
    internal sealed class DatabaseMock
    {
        private static ConcurrentBag<User> Users { get; set; }

        internal static bool AddUser(User user)
        {
            if (Users == null) Users = new ConcurrentBag<User>();
            else if (Users.Any(x => x.Name == user.Name))
            {
                return false; //User already exists
            }

            Users.Add(user);
            return true;
        }

        internal static bool LogIn(User user)
        {
            if (Users == null) Users = new ConcurrentBag<User>();
            if (Users.Any(x => x.Name == user.Name && x.Password == user.Password))
            {
                return true;
            }

            return false;
        }
    }
}
