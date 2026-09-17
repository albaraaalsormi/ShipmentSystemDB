using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application.DTOs;
using System.Collections.Generic;

namespace Application.IServices
{
    public interface IShipmentService
    {
        void Create(ShipmentDto dto);
        ShipmentDto GetById(int id);
        IEnumerable<ShipmentDto> GetAll();
        void Update(ShipmentDto dto);
        void Delete(int id);
    }
}
