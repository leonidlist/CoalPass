using CoalPassDAL.Abstractions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CoalPassDAL.Models
{
    public class Password : IPassword
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public string Website { get; set; }
        public int Category { get; set; }
        public string ImageUrl { get; set; }
    }
}