using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepo _repository;
        public UsersController(IUserRepo repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public ActionResult<User> Add(User user)
        {
            _repository.Add(user);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<User> GetById(long id)
        {
            return _repository.GetById(id);
        }

        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            return _repository.GetAll();
        }

        [HttpGet]
        [Route("todos")]
        public IEnumerable<User> GetGetUsersWithTasks()
        {
            return _repository.GetUsersWithTasks();
        }
    }
}
