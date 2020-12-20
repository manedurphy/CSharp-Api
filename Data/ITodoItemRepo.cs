using System;
using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Data
{
    public interface ITodoItemRepo : IRepository<TodoItem>
    {
    }
}
