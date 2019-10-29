using CoalPassDAL.Models;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace CoalPassDAL.Contexts
{
    public class CoalContext
    {
        IMongoDatabase database;
        IGridFSBucket gridFS;

        public IMongoCollection<User> Users { get => database.GetCollection<User>("Users"); }

        public CoalContext(string connectionString)
        {
            var connection = new MongoUrlBuilder(connectionString);
            var client = new MongoClient(connectionString);

            database = client.GetDatabase(connection.DatabaseName);
            gridFS = new GridFSBucket(database);
        }
    }
}