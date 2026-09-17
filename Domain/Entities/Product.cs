namespace Domain.Entities
{
    public class Product
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public decimal? WeightKg { get; set; }

        public int StockQuantity { get; set; }
    }
}