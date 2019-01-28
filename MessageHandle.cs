using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunlUserClient
{
    class MessageHandle
    {
        public MessageHandle()
        {

        }
        void SendMessage(Message Message)
        {
            //make this stringbuilder and send over ws, use ws listener to display messages instead
            Console.WriteLine("[{0}] {1}: {2}", Message.Time.ToString(), Message.Sender, Message.Text);
        }
    }
}
