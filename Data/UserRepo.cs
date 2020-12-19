using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class UserRepo : IUserRepo
    {
        private readonly WebAPIContext _context;
        public UserRepo(WebAPIContext context)
        {
            _context = context;
        }

        public async Task<User> Create(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> GetbyId(long Id)
        {
            return await _context.Users.FindAsync(Id);
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.Users.Include(user => user.TodoItems).ToListAsync();
        }

    }
}
