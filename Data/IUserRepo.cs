using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Data
{
    public interface IUserRepo
    {
        Task<User> Create(User user);
        Task<User> GetbyId(long Id);
        Task<List<User>> GetAll();
    }
}
