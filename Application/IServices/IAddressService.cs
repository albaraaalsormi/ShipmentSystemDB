using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application.DTOs;
using System.Collections.Generic;

namespace Application.IServices
{
    public interface IAddressService
    {
        void Create(AddressDto dto);
        AddressDto GetById(int id);
        IEnumerable<AddressDto> GetAll();
        void Update(AddressDto dto);
        void Delete(int id);
    }
}
