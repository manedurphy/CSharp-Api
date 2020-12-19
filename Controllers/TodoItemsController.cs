using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/todoitems")]
    public class TodoItemsController : ControllerBase
    {
        private readonly WebAPIContext _context;
        public TodoItemsController(WebAPIContext context)
        {
            _context = context;
        }
        
        [HttpPost]
        public async Task<ActionResult<TodoItem>> Create(TodoItem todoItem)
        {
            TodoItem existingTodo = _context.TodoItems.Where(todo => todo.Name == todoItem.Name).FirstOrDefault();
            User user = await _context.Users.FindAsync(todoItem.UserId);

            if (user == null)
            {
                return NotFound("User could not be found");
            }

            if (existingTodo != null)
            {
                return BadRequest("Task already exists");
            }

            _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync();
            
            return CreatedAtAction(nameof(GetById), new { id = todoItem.Id }, todoItem);

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<TodoItem>> GetById(long id)
        {
            TodoItem todoItem = await _context.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        [HttpGet]
        public List<TodoItem> GetAll()
        {
            return _context.TodoItems.ToList();
        }
    }
}
