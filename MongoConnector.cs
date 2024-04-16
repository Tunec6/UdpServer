using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdpServer
{
    internal class MongoConnector
    {
        private static MongoClient client = new MongoClient("mongodb://localhost:27017");
        private static IMongoDatabase chatDataBase = client.GetDatabase("ChatDB");
        private static IMongoCollection<BsonDocument> chats = chatDataBase.GetCollection<BsonDocument>("Chats");

        public MongoConnector()
        {

        }
    }
}
