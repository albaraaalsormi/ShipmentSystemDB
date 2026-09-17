using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    
        public class AddressDto
        {
            public int AddressID { get; set; }
            public int CustomerID { get; set; }
            public string City { get; set; }
            public string District { get; set; }
            public string AddressDetails { get; set; }
        }
    
}
