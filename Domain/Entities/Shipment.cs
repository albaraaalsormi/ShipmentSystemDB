using System;

namespace Domain.Entities
{
    public class Shipment
    {
        public int ShipmentID { get; set; }

        public int OrderID { get; set; }

        public string TrackingNumber { get; set; }

        public DateTime? ShipmentDate { get; set; }

        public DateTime? EstimatedDeliveryDate { get; set; }

        public string Status { get; set; }
    }
}