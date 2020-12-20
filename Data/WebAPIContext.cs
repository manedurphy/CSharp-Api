using System;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class WebAPIContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }

        public WebAPIContext(DbContextOptions<WebAPIContext> options)
            : base(options)
        {
        }
    }
}
