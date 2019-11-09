using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoalPassDAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using CoalPassDAL.Models;
using CoalPassDAL.Abstractions;

namespace CoalPassAPI.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private IAsyncRepository<User> _usersRepository = new UsersRepository();

        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await _usersRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            //TODO: use services instead of repositories!
            var result = await _usersRepository.Get(id);

            if (result == null)
            {
                return NotFound("User data did not found.");
            }
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]User user)
        {
            if (user == null)
                return BadRequest();

            await _usersRepository.Add(user);
            return Ok(user.Id);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]User user)
        {
            if(user == null)
                return BadRequest();

            await _usersRepository.Update(user);
            return Ok(user);
        }
    }
}