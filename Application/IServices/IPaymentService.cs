using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application.DTOs;
using System.Collections.Generic;

namespace Application.IServices
{
    public interface IPaymentService
    {
        void Create(PaymentDto dto);
        PaymentDto GetById(int id);
        IEnumerable<PaymentDto> GetAll();
        void Update(PaymentDto dto);
        void Delete(int id);
    }
}
