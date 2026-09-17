namespace Domain.Entities
{
    public class Address
    {
        public int AddressID { get; set; }

        public int CustomerID { get; set; }

        public string City { get; set; }

        public string District { get; set; }

        public string AddressDetails { get; set; }
    }
}