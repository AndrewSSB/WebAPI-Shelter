using AdapostAPI.BLL.Interfaces;
using AdapostAPI.DAL;
using AdapostAPI.DAL.Entities;
using AdapostAPI.DAL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdapostAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationManager _locationManager;
        
        public LocationsController(ILocationManager locationManager)
        {
            _locationManager = locationManager;
        } 

        [HttpPost("AddLocation")]
        [Authorize("Admin")]
        public async Task<IActionResult> AddLocation([FromBody] Location location)
        {
            await _locationManager.Create(location);
            return Ok();
        }

        [HttpGet("GetLocation/{id}")]
        public async Task<IActionResult> GetLocation([FromRoute] int id)
        {
            var location = await _locationManager.GetById(id);
            if (location != null)
            {
                return Ok(location);
            }
            return BadRequest("Id-ul introdus este incorect.");
        }

        [HttpGet("GetLocations")]
        public async Task<IActionResult> GetLocations()
        {
            var location = await _locationManager.GetAll();
            if (location != null)
            {
                return Ok(location);
            }

            return BadRequest("Nu exista niciun adapost.");
        }

        [HttpPut("UpdateLocation")]
        [Authorize("Admin")]
        public async Task<IActionResult> UpdateLocation([FromBody] Location location)
        {
            await _locationManager.Update(location);
            return Ok();
        }

        [HttpDelete("DeleteLocation")]
        [Authorize("Admin")]
        public async Task<IActionResult> DeleteLocation([FromQuery] int id)
        {
            await _locationManager.Delete(id);
            return Ok();
        }
    }
}
