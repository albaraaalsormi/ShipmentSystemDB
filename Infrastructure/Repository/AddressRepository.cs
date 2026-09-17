using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AppDbContext _context;

        public AddressRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Address address)
        {
            _context.Addresses.Add(address);
            _context.SaveChanges();
        }

        public void Update(Address address)
        {
            _context.Entry(address).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var address = _context.Addresses.Find(id);

            if (address != null)
            {
                _context.Addresses.Remove(address);
                _context.SaveChanges();
            }
        }

        public Address GetById(int id)
        {
            return _context.Addresses.Find(id);
        }

        public List<Address> GetAll()
        {
            return _context.Addresses.ToList();
        }
    }
}