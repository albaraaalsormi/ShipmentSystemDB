using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application.DTOs;
using System.Collections.Generic;

namespace Application.IServices
{
    public interface ICustomerService
    {
        void Create(CustomerDto dto);
        CustomerDto GetById(int id);
        IEnumerable<CustomerDto> GetAll();
        void Update(CustomerDto dto);
        void Delete(int id);
    }
}
