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
    public class AdapostVizitatorController : ControllerBase
    {
        private readonly IViziteManager _obj;

        public AdapostVizitatorController(IViziteManager obj)
        {
            _obj = obj;
        }

        [HttpPost("AddVizita")]
        public async Task<IActionResult> AddVizita([FromBody] AdapostVizitator obj)
        {
            await _obj.Create(obj);
            return Ok();
        }

        [HttpGet("GetVizita/{id}")]
        public async Task<IActionResult> GetVizita([FromRoute] int id)
        {
            //var adapost = await _context.Adaposts.FirstOrDefaultAsync(x => x.Id == id); // prima metoda de accesare
            var angajat = await _obj.GetById(id);
            if (angajat != null)
            {
                return Ok(angajat);
            }
            return BadRequest("Id-ul introdus este incorect.");
        }

        [HttpGet("GetVizite")]
        public async Task<IActionResult> GetVizite()
        {
            var angajati = await _obj.GetAll();
            if (angajati != null)
            {
                return Ok(angajati);
            }

            return BadRequest("Nu exista nici o vizita.");
        }

        [HttpPut("UpdateVizite")]
        public async Task<IActionResult> UpdateVizite([FromBody] AdapostVizitator obj)
        {
            await _obj.Update(obj);
            return Ok();
        }

        [HttpDelete("DeleteVizita")]
        public async Task<IActionResult> DeleteVizita([FromQuery] int id)
        {
            await _obj.Delete(id);
            return Ok();
        }

        //CRUD
        //C - CREATE
        //R - READ(GET)
        //U - UPDATE(PUT/PATCH)
        //D - DELETE(REMOVE)

        // Linie -> Alta linie F10
        // F11 -> pt o functie (a intra linie cu linie in ea) / altfel f10 se ruleaza si intoarce rez
        // F5 -> continua rularea pana la urmatorul breakpoint
    }
}
