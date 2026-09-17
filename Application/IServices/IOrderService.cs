using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application.DTOs;
using System.Collections.Generic;

namespace Application.IServices
{
    public interface IOrderService
    {
        void Create(OrderDto dto);
        OrderDto GetById(int id);
        IEnumerable<OrderDto> GetAll();
        void Update(OrderDto dto);
        void Delete(int id);
    }
}
