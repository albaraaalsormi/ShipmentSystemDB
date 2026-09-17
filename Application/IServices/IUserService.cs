using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application.DTOs;
using System.Collections.Generic;

namespace Application.IServices
{
    public interface IUserService
    {
        void Create(UserDto dto);
        UserDto GetById(int id);
        IEnumerable<UserDto> GetAll();
        void Update(UserDto dto);
        void Delete(int id);
    }
}