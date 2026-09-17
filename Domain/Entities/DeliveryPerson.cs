namespace Domain.Entities
{
    public class DeliveryPerson
    {
        public int DeliveryPersonID { get; set; }

        public int UserID { get; set; }

        public string FullName { get; set; }

        public string Phone { get; set; }

        public string Status { get; set; }
    }
}