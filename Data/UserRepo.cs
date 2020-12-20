using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class UserRepo : BaseRepository<User>, IUserRepo
    {
        public UserRepo(WebAPIContext context) : base(context)
        {
        }

        public IEnumerable<User> GetUsersWithTasks()
        {
            return WebAPIContext.Users.Include(u => u.TodoItems);
        }

        public WebAPIContext WebAPIContext
        {
            get { return _context;  }
        }
    }
}