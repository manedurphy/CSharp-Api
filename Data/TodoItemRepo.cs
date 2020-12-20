using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class TodoItemRepo : BaseRepository<TodoItem>, ITodoItemRepo
    {
        public TodoItemRepo(WebAPIContext context) : base(context)
        {
        }        
    }
}
