using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.IRepositories
{
    public interface IShipmentRepository
    {
        void Add(Shipment shipment);

        void Update(Shipment shipment);

        void Delete(int id);

        Shipment GetById(int id);

        List<Shipment> GetAll();
    }
}
