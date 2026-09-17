using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class DeliveryPersonDto
    {
        public int DeliveryPersonID { get; set; }
        public int UserID { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Status { get; set; }
    }
}
