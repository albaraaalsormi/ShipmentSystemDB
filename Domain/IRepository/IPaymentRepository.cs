using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.IRepositories
{
    public interface IPaymentRepository
    {
        void Add(Payment payment);

        void Update(Payment payment);

        void Delete(int id);

        Payment GetById(int id);

        List<Payment> GetAll();
    }
}