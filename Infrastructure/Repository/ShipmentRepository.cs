using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class ShipmentRepository : IShipmentRepository
    {
        private readonly AppDbContext _context;

        public ShipmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Shipment shipment)
        {
            _context.Shipments.Add(shipment);
            _context.SaveChanges();
        }

        public void Update(Shipment shipment)
        {
            _context.Entry(shipment).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var shipment = _context.Shipments.Find(id);

            if (shipment != null)
            {
                _context.Shipments.Remove(shipment);
                _context.SaveChanges();
            }
        }

        public Shipment GetById(int id)
        {
            return _context.Shipments.Find(id);
        }

        public List<Shipment> GetAll()
        {
            return _context.Shipments.ToList();
        }
    }
}