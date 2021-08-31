using MongoDB.Driver;

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
    }
}
