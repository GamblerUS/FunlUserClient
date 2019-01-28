using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunlUserClient
{
    class WebsocketHandle
    {
        public string Address;
        private DateTime LastMessageTime;

        public WebsocketHandle(string Address)
        {
            this.Address = Address;
        }

        public void Send(Message Message)
        {
            //
            StringBuilder StringBuilder = new StringBuilder();
            StringBuilder.AppendFormat("{0}|{1}|{2}", Message.Text,Message.Time.ToString(),Message.Sender.ID);
            // send this shit -> StringBuilder.ToString();

        }
        public void Recieve()
        {

        }

      
        
    }
}
