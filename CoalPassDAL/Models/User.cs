using System.Security;
using System;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using CoalPassDAL.Abstractions;

namespace CoalPassDAL.Models
{
    public class User
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Theme { get; set; }
        public string ImageLink { get; set; }
        public IAsyncRepository<IPassword> Passwords { get; set; }
    }
}
