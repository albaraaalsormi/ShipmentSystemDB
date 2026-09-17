using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.IRepositories
{
    public interface IDeliveryPersonRepository
    {
        void Add(DeliveryPerson deliveryPerson);

        void Update(DeliveryPerson deliveryPerson);

        void Delete(int id);

        DeliveryPerson GetById(int id);

        List<DeliveryPerson> GetAll();
    }
}