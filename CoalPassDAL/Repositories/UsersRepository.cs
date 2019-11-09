using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoalPassDAL.Abstractions;
using CoalPassDAL.Contexts;
using CoalPassDAL.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CoalPassDAL.Repositories
{
    public class UsersRepository : IAsyncRepository<User>
    {
        private MongoDbContext _context;
        public UsersRepository(MongoDbContext context)
        {
            _context = context;
        }

        public async Task Add(User item)
        {
            await _context.Users.InsertOneAsync(item);
        }

        public async Task<User> Get(string id)
        {
            return await _context.Users.Find(new BsonDocument("_id", new ObjectId(id))).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var builder = new FilterDefinitionBuilder<User>();
            var filter = builder.Empty;

            return await _context.Users.Find(filter).ToListAsync();
        }

        public async Task Remove(User item)
        {
            await _context.Users.DeleteOneAsync(new BsonDocument("_id", new ObjectId(item.Id)));
        }

        public async Task Remove(string id)
        {
            await _context.Users.DeleteOneAsync(new BsonDocument("_id", new ObjectId(id)));
        }

        public async Task Update(User item)
        {
            await _context.Users.ReplaceOneAsync(new BsonDocument("_id", new ObjectId(item.Id)), item);  
        }
    }
}