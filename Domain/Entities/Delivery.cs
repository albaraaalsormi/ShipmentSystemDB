using System;

namespace Domain.Entities
{
    public class Delivery
    {
        public int DeliveryID { get; set; }

        public int ShipmentID { get; set; }

        public int AddressID { get; set; }

        public int DeliveryPersonID { get; set; }

        public decimal DeliveryFee { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public string Status { get; set; }
    }
}