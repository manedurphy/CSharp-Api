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
        public ActionResult<User> Create(User user)
        {
            _repository.Create(user);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<User>> GetById(long id)
        {
            return await _repository.GetbyId(id);
        }

        [HttpGet]
        public async Task<List<User>> GetAll()
        {
            return await _repository.GetAll();
        }
    }
}
