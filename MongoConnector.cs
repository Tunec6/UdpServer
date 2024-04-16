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

        public static void addChat (Chat chat)
        {
            chats.InsertOne(chat);
        }

        public static void findChat(Chat chat)  
        {
            var collection = chatDataBase.GetCollection<Chat>("chats");
            List<Chat> chats = collection.Find(new BsonDocument()).ToList();
        }


    }
}
