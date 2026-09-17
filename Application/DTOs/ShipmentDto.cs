using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.DTOs
{
    public class ShipmentDto
    {
        public int ShipmentID { get; set; }
        public int OrderID { get; set; }
        public string TrackingNumber { get; set; }
        public DateTime? ShipmentDate { get; set; }
        public DateTime? EstimatedDeliveryDate { get; set; }
        public string Status { get; set; }
    }
}
