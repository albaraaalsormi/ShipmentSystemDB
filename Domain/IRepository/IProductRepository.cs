using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.IRepositories
{
    public interface IProductRepository
    {
        void Add(Product product);

        void Update(Product product);

        void Delete(int id);

        Product GetById(int id);

        List<Product> GetAll();
    }
}
