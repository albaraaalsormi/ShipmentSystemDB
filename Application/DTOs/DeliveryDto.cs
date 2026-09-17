using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.DTOs
{
    public class DeliveryDto
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
