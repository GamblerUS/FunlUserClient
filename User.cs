using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunlUserClient
{
    class User
    {
        public int ID;
        public string Name;
        public string Password;
        public int Status = 0;
        //will not use enums for rank, for symplicity in storage in sql
        public int Rank = 0;
        public int Posts = 0;
        public int Funds = 0;
        //creation var is stored in sql as string
        public DateTime Creation;
        public User(int ID, string Name, string Password, DateTime Creation)
        {
            this.ID = ID;
            this.Name = Name;
            this.Password = Password;
            this.Creation = Creation;
        }

    }
}
