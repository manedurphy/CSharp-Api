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
        private readonly ITodoItemRepo _repository;
        public TodoItemsController(ITodoItemRepo repository)
        {
            _repository = repository;
        }
        
        [HttpPost]
        public ActionResult<TodoItem> Add(TodoItem todoItem)
        {
            _repository.Add(todoItem);
            return CreatedAtAction(nameof(GetById), new { id = todoItem.Id }, todoItem);

        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<TodoItem> GetById(long id)
        {
            return _repository.GetById(id);
        }

        [HttpGet]
        public IEnumerable<TodoItem> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
