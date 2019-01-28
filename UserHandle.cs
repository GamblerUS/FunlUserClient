using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunlUserClient
{
    class UserHandle
    {
        public List<User> Users = new List<User>();
        private SQLListener SQLListener;
        public UserHandle()
        {

        }

        void CreateUser(string Name, string Password)
        {
            Users.Add(new User(Users.Count(), Name, Password, DateTime.UtcNow));

        }
        
        User GetUser(string Name)
        {
            foreach (User u in Users)
            {
                if(u.Name == Name)
                {
                    return u;
                    
                }
            }
            return null;
        }
        private void UpdateUsers()
        {

        }
    }
}
