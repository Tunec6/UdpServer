﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace UdpServer.Models
{
    public class Message
    {
        public string Command { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        public string IpFrom { get; set; }

        public string IpTo { get; set; }


        public Message(string command, string text, string ipTo, string ipFrom)
        {
            Command = command;
            Text = text;
            IpFrom = ipFrom;
            IpTo = ipTo;

            DateTime = DateTime.Now;
        }

        public string ToJSON()
        {
            return JsonSerializer.Serialize(this);
        }

        public static Message FromJSON(string json)
        {
            return JsonSerializer.Deserialize<Message>(json);
        }

    }
}
