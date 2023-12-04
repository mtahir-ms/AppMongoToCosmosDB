using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace EStore.Models
{
    public class ProductModel
    {
        [BsonIgnoreExtraElements]
        public class Product
        {
            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public string _id { get; set; } = string.Empty;

            [BsonElement("ProductName")]
            public string ProductName { get; set; } = string.Empty;
            [BsonElement("Price")]
            public string Price { get; set; } = string.Empty;
            [BsonElement("Quantity")]
            public string Quantity { get; set; } = string.Empty;
           
        }
    }
}
