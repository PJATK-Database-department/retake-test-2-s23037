using ApbdTest2.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApbdTest2.Controllers
{
    public class RemizaController : Controller
    {
        private readonly IDbService _dbService;

        public RemizaController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet("{idFireTruck}")]
        public async Task<IActionResult> GetTruck([FromRoute] int idFireTruck)
        {
            if (!await _dbService.DoesFireTruckExist(idFireTruck))
            {
                return NotFound("Truck doesnt exist");
            }
            var truck = _dbService.GetTruckAsync(idFireTruck);
            return Ok(truck);
        }
        [HttpPost("{idAction}")]
        public async Task<IActionResult> UpdateEnd([FromRoute] int idAction, DateTime time)
        {
            if (await _dbService.HaveActionEndenAsync(idAction){
                return BadRequest("Action has ended already");
            }
            await _dbService.UpdateEndAsync(idAction, time);
            return NoContent();
        }
    }
}
