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
        private IAsyncRepository<User> _usersRepository;

        public UsersController(IAsyncRepository<User> usersRepository)
        {
            _usersRepository = usersRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await _usersRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<User> Get(string id)
        {
            return await _usersRepository.Get(id);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]User user)
        {
            if (user == null)
                return BadRequest();

            await _usersRepository.Add(user);
            return Ok(user);
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