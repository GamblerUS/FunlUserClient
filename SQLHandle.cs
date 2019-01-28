using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunlUserClient
{
    class SQLHandle
    {
        //Various accessors for user variables
        public enum ParseAccessor
        {
            ID,
            Name,
            Password,
            Posts,
            Creation,
            Funds,
            Rank,
            NewestClientVersion,

        };
        public string Address;
        public SQLHandle(string Address)
        {
            this.Address = Address;
        }

        public string Parse(ParseAccessor ParseAccessor)
        {

            return;

        }
    }
}
