using System.Collections.Generic;
using System.Threading.Tasks;
using CoalPassDAL.Abstractions;
using CoalPassDAL.Contexts;
using CoalPassDAL.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CoalPassDAL.Repositories
{
    public class PasswordsRepository : IAsyncRepository<Password>
    {
        private CoalContext _context;
        public PasswordsRepository(string connectionString = "mongodb://localhost:27017/CoalPassAPI")
        {
            _context = new CoalContext(connectionString);
        }

        public async Task Add(Password item)
        {
            await _context.Passwords.InsertOneAsync(item);
        }

        public async Task<Password> Get(string id)
        {
            return await _context.Passwords.Find(new BsonDocument("_id", new ObjectId(id))).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Password>> GetAll()
        {
            var builder = new FilterDefinitionBuilder<Password>();
            var filter = builder.Empty;

            return await _context.Passwords.Find(filter).ToListAsync();
        }

        public async Task Remove(Password item)
        {
            await _context.Passwords.DeleteOneAsync(new BsonDocument("_id", new ObjectId(item.Id)));
        }

        public async Task Remove(string id)
        {
            await _context.Passwords.DeleteOneAsync(new BsonDocument("_id", new ObjectId(id)));
        }
    }
}