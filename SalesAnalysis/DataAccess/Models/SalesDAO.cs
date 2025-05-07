using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SalesAnalysis.Models.Entities
{
    public class SalesDAO
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("order_id")]
        public int OrderId { get; set; }

        [BsonElement("product_id")]
        public string ProductId { get; set; } = string.Empty;

        [BsonElement("customer_id")]
        public string CustomerId { get; set; } = string.Empty;

        [BsonElement("customer_name")]
        public string CustomerName { get; set; } = string.Empty;

        [BsonElement("customer_email")]
        public string CustomerEmail { get; set; } = string.Empty;

        [BsonElement("customer_address")]
        public string CustomerAddress { get; set; } = string.Empty;

        [BsonElement("product_name")]
        public string ProductName { get; set; } = string.Empty;

        [BsonElement("category")]
        public string Category { get; set; } = string.Empty;

        [BsonElement("region")]
        public string Region { get; set; } = string.Empty;

        [BsonElement("date_of_sale")]
        public DateTime DateOfSale { get; set; }

        [BsonElement("quantity_sold")]
        public int QuantitySold { get; set; }

        [BsonElement("unit_price")]
        public decimal UnitPrice { get; set; }

        [BsonElement("discount")]
        public decimal Discount { get; set; }

        [BsonElement("shipping_cost")]
        public decimal ShippingCost { get; set; }

        [BsonElement("payment_method")]
        public string PaymentMethod { get; set; } = string.Empty;
    }
}
