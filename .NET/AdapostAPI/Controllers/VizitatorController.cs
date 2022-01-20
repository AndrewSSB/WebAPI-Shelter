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
    public class VizitatorController : ControllerBase
    {
        private readonly IVizitatorManager _obj;

        public VizitatorController(IVizitatorManager obj)
        {
            _obj = obj;
        }

        [HttpPost("AddVizitator")]
        public async Task<IActionResult> AddVizitator([FromBody] Vizitator obj)
        {
            await _obj.Create(obj);
            return Ok();
        }

        [HttpGet("GetVizitator/{id}")]
        public async Task<IActionResult> GetVizitator([FromRoute] int id)
        {
            //var adapost = await _context.Adaposts.FirstOrDefaultAsync(x => x.Id == id); // prima metoda de accesare
            var angajat = await _obj.GetById(id);
            if (angajat != null)
            {
                return Ok(angajat);
            }
            return BadRequest("Id-ul introdus este incorect.");
        }

        [HttpGet("GetVizitatori")]
        public async Task<IActionResult> GetVizitatori()
        {
            var angajati = await _obj.GetAll();
            if (angajati != null)
            {
                return Ok(angajati);
            }

            return BadRequest("Nu exista niciun vizitator.");
        }

        [HttpPut("UpdateVizitator")]
        public async Task<IActionResult> UpdateVizitator([FromBody] Vizitator obj)
        {
            await _obj.Update(obj);
            return Ok();
        }

        [HttpDelete("DeleteVizitator")]
        public async Task<IActionResult> DeleteVizitator([FromQuery] int id)
        {
            await _obj.Delete(id);
            return Ok();
        }
    }
}
