using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FunlUserClient
{
    class ChatActivity
    {
        readonly WebsocketHandle WebsocketHandle = new WebsocketHandle();

        void Send(string Message)
        {
            WebsocketHandle.Send(Message);

        }
        void InitActivity()
        {   
            Timer Timer = new Timer(Update, null, 0, 500);
        }
        void Update(object info)
        {
            
        }
    
    }
  
}
