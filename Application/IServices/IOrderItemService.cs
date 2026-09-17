using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application.DTOs;
using System.Collections.Generic;

namespace Application.IServices
{
    public interface IOrderItemService
    {

        void Create(OrderItemDto dto);
        OrderItemDto GetById(int id);
        IEnumerable<OrderItemDto> GetAll();
        void Update(OrderItemDto dto);
        void Delete(int id);
    }
}
