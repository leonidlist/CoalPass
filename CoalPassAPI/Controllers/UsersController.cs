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
        public IEnumerable<User> Get()
        {
            return _usersRepository.GetAll().Result;
        }

        [HttpGet("{id}")]
        public User Get(string id)
        {
            return _usersRepository.Get(id).Result;
        }

        [HttpPut]
        public IActionResult Put([FromBody]User user) {
            if(user == null)
                return BadRequest();
            
            _usersRepository.Add(user).GetAwaiter().GetResult();
            return Ok(user);
        }
    }
}