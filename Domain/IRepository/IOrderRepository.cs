using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.IRepositories
{
    public interface IOrderRepository
    {
        void Add(Order order);

        void Update(Order order);

        void Delete(int id);

        Order GetById(int id);

        List<Order> GetAll();
    }
}
