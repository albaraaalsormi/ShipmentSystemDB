using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application.DTOs;
using System.Collections.Generic;

namespace Application.IServices
{
    public interface IProductService
    {
        void Create(ProductDto dto);
        ProductDto GetById(int id);
        IEnumerable<ProductDto> GetAll();
        void Update(ProductDto dto);
        void Delete(int id);
    }
}
