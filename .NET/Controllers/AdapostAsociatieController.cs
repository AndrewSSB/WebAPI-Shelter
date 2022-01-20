using AdapostAPI.BLL.Interfaces;
using AdapostAPI.DAL;
using AdapostAPI.DAL.Entities;
using AdapostAPI.DAL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdapostAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdapostAsociatieController : ControllerBase
    {
        private readonly ISponsorizareManager _obj;

        public AdapostAsociatieController(ISponsorizareManager obj)
        {
            _obj = obj;
        }

        [HttpPost("AddSponsorizare")]
        [Authorize("Admin")]
        public async Task<IActionResult> AddSponsorizare([FromBody] AdapostAsociatie obj)
        {
            await _obj.Create(obj);
            return Ok();
        }

        [HttpGet("GetSponsorizare/{id}")]
        public async Task<IActionResult> GetSponsorizare([FromRoute] int id)
        {
            //var adapost = await _context.Adaposts.FirstOrDefaultAsync(x => x.Id == id); // prima metoda de accesare
            var angajat = await _obj.GetById(id);
            if (angajat != null)
            {
                return Ok(angajat);
            }
            return BadRequest("Id-ul introdus este incorect.");
        }

        [HttpGet("GetSponsorizari")]
        public async Task<IActionResult> GetSponsorizari()
        {
            var angajati = await _obj.GetAll();
            if (angajati != null)
            {
                return Ok(angajati);
            }

            return BadRequest("Nu exista nici o sponsorizare.");
        }

        [HttpPut("UpdateSponsorizare")]
        [Authorize("Admin")]
        public async Task<IActionResult> UpdateSponsorizare([FromBody] AdapostAsociatie obj)
        {
            await _obj.Update(obj);
            return Ok();
        }

        [HttpDelete("DeleteSponsorizare")]
        [Authorize("Admin")]
        public async Task<IActionResult> DeleteSponsorizare([FromQuery] int id)
        {
            await _obj.Delete(id);
            return Ok();
        }
    }
}
