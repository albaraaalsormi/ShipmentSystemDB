namespace Domain.Entities
{
    public class Customer
    {
        public int CustomerID { get; set; }

        public int UserID { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}