using Azakaw.Complaints.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azakaw.Complaints.API.DataProviders
{
    public interface IUserDataAdapter
    {
        User GetUserByUserNameAndPassword(string username, string password);
    }
   
    public class UserDataAdapter : IUserDataAdapter
    {
        private List<User> _users = new List<User>
        {
            new User { Id = "1", FirstName = "Super", LastName = "Admin", Username = "superadmin", Password = "superadmin" },
            new User { Id = "1", FirstName = "Admin", LastName = "Admin", Username = "admin", Password = "admin" }
        };
        public User GetUserByUserNameAndPassword(string username, string password)
        {
            try
            {
                var user = _users.SingleOrDefault(x => x.Username == username && x.Password == password);
                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
