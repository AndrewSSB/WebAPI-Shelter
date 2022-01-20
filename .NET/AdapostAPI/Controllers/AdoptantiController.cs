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
    public class AdoptantiController : ControllerBase
    {
        private readonly IAdoptantiManager _adoptantiManager;

        public AdoptantiController(IAdoptantiManager adoptantiManager)
        {
            _adoptantiManager = adoptantiManager;
        }

        [HttpPost("AddAdoptant")]
        public async Task<IActionResult> AddAdoptant([FromBody] Adoptanti adoptant)
        {
            await _adoptantiManager.Create(adoptant);
            return Ok();
        }

        [HttpGet("GetAdoptant/{id}")]
        public async Task<IActionResult> GetAdoptant([FromRoute] int id)
        {
            //var adapost = await _context.Adaposts.FirstOrDefaultAsync(x => x.Id == id); // prima metoda de accesare
            var angajat = await _adoptantiManager.GetById(id);
            if (angajat != null)
            {
                return Ok(angajat);
            }
            return BadRequest("Id-ul introdus este incorect.");
        }

        [HttpGet("GetAdoptanti")]
        public async Task<IActionResult> GetAdoptanti()
        {
            var angajati = await _adoptantiManager.GetAll();
            if (angajati != null)
            {
                return Ok(angajati);
            }

            return BadRequest("Nu exista niciun adoptant.");
        }

        [HttpPut("UpdateAdoptant")]
        public async Task<IActionResult> UpdateAdoptant([FromBody] Adoptanti adoptanti)
        {
            await _adoptantiManager.Update(adoptanti);
            return Ok();
        }

        [HttpDelete("DeleteAdoptant")]
        public async Task<IActionResult> DeleteAdoptant([FromQuery] int id)
        {
            await _adoptantiManager.Delete(id);
            return Ok();
        }
    }
}
