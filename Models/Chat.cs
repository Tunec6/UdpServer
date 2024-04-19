using MongoDB.Bson;
using MongoDB.Driver.Core.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace UdpServer.Models
{
    public class Chat
    {
        public string fileName;
        public List<Message> Messages =  new List<Message>();

        public Chat(string chatName) 
        {
            this.fileName = chatName;
        }

        public IEnumerable<string> Name { get; internal set; }
    }
}
