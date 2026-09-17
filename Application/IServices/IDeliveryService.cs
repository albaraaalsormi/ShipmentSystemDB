using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application.DTOs;
using System.Collections.Generic;

namespace Application.IServices
{
    public interface IDeliveryService
    {
        void Create(DeliveryDto dto);
        DeliveryDto GetById(int id);
        IEnumerable<DeliveryDto> GetAll();
        void Update(DeliveryDto dto);
        void Delete(int id);
    }
}
