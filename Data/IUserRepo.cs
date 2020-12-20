using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Data
{
    public interface IUserRepo : IRepository<User>
    {
        IEnumerable<User> GetUsersWithTasks();
    }
}
