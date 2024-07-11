using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace DataModels.models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public decimal SellingPrice { get; set; }

        public decimal OriginalPrice { get; set; }

        public int StockQuantity { get; set; }

        public string Description { get; set; }
    }
}
