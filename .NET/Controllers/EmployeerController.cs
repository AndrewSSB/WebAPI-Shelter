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
    public class EmployeerController : ControllerBase
    {
        private readonly IAngajatManager _angajatManager;

        public EmployeerController(IAngajatManager angajatManager)
        {
            _angajatManager = angajatManager;
        }

        [HttpPost("AddAngajat")]
        [Authorize("Admin")]
        public async Task<IActionResult> AddAngajat([FromBody] Employeer angajat)
        {
            await _angajatManager.Create(angajat);
            return Ok();
        }

        [HttpGet("GetAngajat/{id}")]
        public async Task<IActionResult> GetAngajat([FromRoute] int id)
        {
            //var adapost = await _context.Adaposts.FirstOrDefaultAsync(x => x.Id == id); // prima metoda de accesare
            var angajat = await _angajatManager.GetById(id);
            if (angajat != null)
            {
                return Ok(angajat);
            }
            return BadRequest("Id-ul introdus este incorect.");
        }

        [HttpGet("GetAngajati")]
        public async Task<IActionResult> GetAngajati()
        {
            var angajati = await _angajatManager.GetAll();
            if (angajati != null)
            {
                return Ok(angajati);
            }

            return BadRequest("Nu exista niciun angajat.");
        }

        [HttpPut("UpdateAngajat")]
        [Authorize("Admin")]
        public async Task<IActionResult> UpdateAngajat([FromBody] Employeer angajat)
        {
            await _angajatManager.Update(angajat);
            return Ok();
        }

        [HttpDelete("DeleteAngajat")]
        [Authorize("Admin")]
        public async Task<IActionResult> DeteleAngajat([FromQuery] int id)
        {
            await _angajatManager.Delete(id);
            return Ok();
        }
    }
}
