using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.IRepositories
{
    public interface IUserRepository
    {
        void Add(User user);

        void Update(User user);

        void Delete(int id);

        User GetById(int id);

        List<User> GetAll();
    }
}
