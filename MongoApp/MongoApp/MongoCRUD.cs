using MongoDB.Bson;
using MongoDB.Driver;
using System;
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

        /// <summary>
        /// Generic insert method allows any object
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="table">table</param>
        /// <param name="record">records</param>
        public void InsertRecord<T>(string table, T record)
        {
            var collection = _db.GetCollection<T>(table);
            collection.InsertOne(record);
        }

        /// <summary>
        /// To fetch all the records from the table/collections.
        /// Its good when you have a smaller number of records/documents.
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="table">table</param>
        /// <returns>All documents from a collection.</returns>
        public List<T> LoadRecords<T>(string table)
        {
            var collection = _db.GetCollection<T>(table);
            return collection.Find(new BsonDocument()).ToList();
        }

        /// <summary>
        /// Get a record from a collection based on id.
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="table">table</param>
        /// <param name="id">id</param>
        /// <returns>Returns a single document from a collection based on Id.</returns>
        public T LoadRecordById<T>(string table, Guid id)
        {
            var collection = _db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("Id", id);
            return collection.Find(filter).FirstOrDefault();
        }

        /// <summary>
        /// Either update or insert the record into the collection.
        /// If id is not match and based on IsUpsert = true then it inserts
        /// If id is match then record is going to update.
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="table">table</param>
        /// <param name="id">id</param>
        /// <param name="record">record</param>
        public void UpdateRecord<T>(string table, Guid id, T record)
        {
            var collection = _db.GetCollection<T>(table);

            var result = collection.ReplaceOne(
                new BsonDocument("_id", id),
                record,
                new ReplaceOptions { IsUpsert = true });
        }
    }
}
