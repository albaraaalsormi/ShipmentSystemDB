using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.IRepositories
{
    public interface ICustomerRepository
    {
        void Add(Customer customer);

        void Update(Customer customer);

        void Delete(int id);

        Customer GetById(int id);

        List<Customer> GetAll();
    }
}
