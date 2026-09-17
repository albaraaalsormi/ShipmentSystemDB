using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class DeliveryPersonRepository : IDeliveryPersonRepository
    {
        private readonly AppDbContext _context;

        public DeliveryPersonRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(DeliveryPerson deliveryPerson)
        {
            _context.DeliveryPersons.Add(deliveryPerson);
            _context.SaveChanges();
        }

        public void Update(DeliveryPerson deliveryPerson)
        {
            _context.Entry(deliveryPerson).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var deliveryPerson = _context.DeliveryPersons.Find(id);

            if (deliveryPerson != null)
            {
                _context.DeliveryPersons.Remove(deliveryPerson);
                _context.SaveChanges();
            }
        }

        public DeliveryPerson GetById(int id)
        {
            return _context.DeliveryPersons.Find(id);
        }

        public List<DeliveryPerson> GetAll()
        {
            return _context.DeliveryPersons.ToList();
        }
    }
}