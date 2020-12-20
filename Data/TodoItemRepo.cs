using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class TodoItemRepo : BaseRepository<TodoItem>, ITodoItemRepo
    {
        public TodoItemRepo(WebAPIContext context) : base(context)
        {
        }

        public WebAPIContext WebAPIContext
        {
            get { return _context; }
        }

        public TodoItem Find(TodoItem todoItem)
        {
            return WebAPIContext.TodoItems.Where(t => t.Name == todoItem.Name).FirstOrDefault();
        }
    }
}
