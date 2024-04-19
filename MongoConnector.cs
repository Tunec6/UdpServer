using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdpServer.Models;

namespace UdpServer
{
    internal class  MongoConnector
    {
        private static MongoClient client = new MongoClient("mongodb://localhost:27017");
        private static IMongoDatabase chatDataBase = client.GetDatabase("ChatDB");
        private static IMongoCollection<Chat> chats = chatDataBase.GetCollection<Chat>("chats");
        private static void UpdateChat(Chat chat)
        {
            var filter = new BsonDocument { { "fileName", chat.fileName } };

            var update = Builders<Chat>.Update.Set(x => x.Messages, chat.message); // Обновляем последний элемент массива "Messages"
            chats.UpdateOne(filter, update);
        }
        public static void addChat (Chat chat)
        {
            chats.InsertOne(chat);
        }

        public static Chat findOneChat(Chat chat)  
        {
            var filter = new BsonDocument { { "Name", chat.fileName } };
            var chatsArray = chats.Find(filter).ToListAsync();
            foreach (var item in chatsArray.Result)
            {
                return item;
            }
            return null;
        }


        public static void UpdateData(Chat chat)
        {
            Chat findChat =  findOneChat(chat);
            if (findChat == null)
            {
                addChat(chat);
            }
            else
            {
                UpdateChat(chat);
            }
        }

    }
}
