using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.IRepositories
{
    public interface IDeliveryRepository
    {
        void Add(Delivery delivery);

        void Update(Delivery delivery);

        void Delete(int id);

        Delivery GetById(int id);

        List<Delivery> GetAll();
    }
}
