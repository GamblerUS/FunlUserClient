using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunlUserClient
{
    class Message
    {
        public string Text;
        public User Sender;
        public DateTime Time;
        public Message(string Message, User Sender)
        {
            this.Sender = Sender;
            this.Text = Message;
            this.Time = DateTime.UtcNow;
        }
        
    }
}
