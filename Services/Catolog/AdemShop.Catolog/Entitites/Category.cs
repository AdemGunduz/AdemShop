using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AdemShop.Catolog.Entitites
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; } 
        public string CategoryName { get; set; }
    }
}
