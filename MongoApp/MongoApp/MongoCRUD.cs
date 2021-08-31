using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

namespace MongoApp
{
    public class MongoCRUD
    {
        private IMongoDatabase _db;

        public MongoCRUD(string databaseName)
        {
            // If creates an instance without any connectionString then it is going to connect localhost:27017
            var client = new MongoClient();
            // var client = new MongoClient("mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass&directConnection=true&ssl=false");
            _db = client.GetDatabase(databaseName);
        }

        public void InsertRecord<T>(string table, T record)
        {
            var collection = _db.GetCollection<T>(table);
            collection.InsertOne(record);
        }

        /// <summary>
        /// To fetch all the records from the table/collections.
        /// Its good when you have a smaller number of records/documents.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <returns></returns>
        public List<T> LoadRecords<T>(string table)
        {
            var collection = _db.GetCollection<T>(table);
            return collection.Find(new BsonDocument()).ToList();
        }
    }
}
