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
    public class AsociatieController : ControllerBase
    {
        private readonly IAsociatieManager _asociatieManager;

        public AsociatieController(IAsociatieManager asociatieManager)
        {
            _asociatieManager = asociatieManager;
        }

        [HttpPost("AddAsociatie")]
        [Authorize("Admin")]
        public async Task<IActionResult> AddAsociatie([FromBody] Asociatie asociatie)
        {
            await _asociatieManager.Create(asociatie);
            return Ok();
        }

        [HttpGet("GetAsociatie/{id}")]
        public async Task<IActionResult> GetAsociatie([FromRoute] int id)
        {
            //var adapost = await _context.Adaposts.FirstOrDefaultAsync(x => x.Id == id); // prima metoda de accesare
            var angajat = await _asociatieManager.GetById(id);
            if (angajat != null)
            {
                return Ok(angajat);
            }
            return BadRequest("Id-ul introdus este incorect.");
        }

        [HttpGet("GetAsociati")]
        public async Task<IActionResult> GetAsociati()
        {
            var angajati = await _asociatieManager.GetAll();
            if (angajati != null)
            {
                return Ok(angajati);
            }

            return BadRequest("Nu exista nici o asociatie.");
        }

        [HttpPut("UpdateAsociatie")]
        [Authorize("Admin")]
        public async Task<IActionResult> UpdateAsociatie([FromBody] Asociatie asociatie)
        {
            await _asociatieManager.Update(asociatie);
            return Ok();
        }

        [HttpDelete("DeleteAsociatie")]
        [Authorize("Admin")]
        public async Task<IActionResult> DeleteAsociatie([FromQuery] int id)
        {
            await _asociatieManager.Delete(id);
            return Ok();
        }
    }
}
