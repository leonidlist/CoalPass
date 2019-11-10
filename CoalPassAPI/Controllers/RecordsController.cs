using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoalPassBLL.DTO;
using CoalPassBLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoalPassAPI.Controllers
{
    [Route("api/[controller]")]
    public class RecordsController : Controller
    {
        private readonly IService<RecordDTO> _recordsService;

        public RecordsController(IService<RecordDTO> recordsService)
        {
            _recordsService = recordsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _recordsService.GetAll();

            if (result == null)
            {
                return NotFound("Records did not found.");
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await _recordsService.Get(id);

            if (result == null)
            {
                return NotFound("Record did not found.");
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RecordDTO record)
        {
            if (record == null)
                return BadRequest();

            await _recordsService.Add(record);
            return Ok(record.Id);
        }

        //TODO: implement other methods
    }
}