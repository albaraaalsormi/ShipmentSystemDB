using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class DeliveryRepository : IDeliveryRepository
    {
        private readonly AppDbContext _context;

        public DeliveryRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Delivery delivery)
        {
            _context.Deliveries.Add(delivery);
            _context.SaveChanges();
        }

        public void Update(Delivery delivery)
        {
            _context.Entry(delivery).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var delivery = _context.Deliveries.Find(id);

            if (delivery != null)
            {
                _context.Deliveries.Remove(delivery);
                _context.SaveChanges();
            }
        }

        public Delivery GetById(int id)
        {
            return _context.Deliveries.Find(id);
        }

        public List<Delivery> GetAll()
        {
            return _context.Deliveries.ToList();
        }
    }
}