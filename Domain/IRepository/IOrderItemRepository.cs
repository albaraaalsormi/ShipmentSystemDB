using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.IRepositories
{
    public interface IOrderItemRepository
    {
        void Add(OrderItem orderItem);

        void Update(OrderItem orderItem);

        void Delete(int id);

        OrderItem GetById(int id);

        List<OrderItem> GetAll();
    }
}
