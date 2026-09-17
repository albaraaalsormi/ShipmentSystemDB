using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application.DTOs;
using System.Collections.Generic;

namespace Application.IServices
{
    public interface IDeliveryPersonService
    {
        void Create(DeliveryPersonDto dto);
        DeliveryPersonDto GetById(int id);
        IEnumerable<DeliveryPersonDto> GetAll();
        void Update(DeliveryPersonDto dto);
        void Delete(int id);
    }
}
