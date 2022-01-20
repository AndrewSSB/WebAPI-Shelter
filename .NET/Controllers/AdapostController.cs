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
    public class AdapostController : ControllerBase
    {
        private readonly IAdapostManager _adapostManager;
        public AdapostController(IAdapostManager adapostManager)
        {
            _adapostManager = adapostManager;
        }

        [HttpPost("AddAdapost")]
        //[Authorize("Admin")]
        public async Task<IActionResult> AddAdapost([FromBody] Adapost adapost)
        {
            await _adapostManager.Create(adapost);
            return Ok();
        }

        [HttpGet("GetAdapost/{id}")]
        public async Task<IActionResult> GetAdapost([FromRoute] int id)
        {
            //var adapost = await _context.Adaposts.FirstOrDefaultAsync(x => x.Id == id); // prima metoda de accesare
            var adapost = await _adapostManager.GetById(id);
            if (adapost != null)
            {
                return Ok(adapost);
            }
            return BadRequest("Id-ul introdus este incorect.");
        }

        [HttpGet("GetAdaposts")]
        //[Authorize("Admin")]
        public async Task<IActionResult> GetAdaposts()
        {
            var adapost = await _adapostManager.GetAll();
            if (adapost != null)
            {
                return Ok(adapost);
            }

            return BadRequest("Nu exista niciun adapost.");
        }

        [HttpPut("UpdateAdapost")]
        [Authorize("Admin")]
        public async Task<IActionResult> UpdateAdapost([FromBody] Adapost adapost)
        {
            var test = adapost.Id;
            await _adapostManager.Update(adapost);
            return Ok();
        }

        [HttpDelete("DeleteAdapost")]
        [Authorize("Admin")]
        public async Task<IActionResult> GetAdaposts([FromQuery] int id)
        {
            await _adapostManager.Delete(id);
            //var adapost = await _adapostManager.GetById(id);
            return Ok();
        }
       
        [HttpGet("AdapostDetalisModel")]
        public async Task<IActionResult> AdapostDetailsModel([FromQuery] int id)
        {
            var adapost = await _adapostManager.AdapostDetails(id);
            return Ok(adapost);
        }

        [HttpGet("ListaDeAdaposturi")]
        public async Task<IActionResult> ListaDeAdaposturi()
        {
            var adapost = await _adapostManager.GetNumeSiIdAdapost();
            return Ok(adapost);
        }

        [HttpGet("get-group-by")]
        public async Task<IActionResult> GetGroupBy()
        {
            var group = await _adapostManager.GetByGroup();
            return Ok(group);
        }

        [HttpGet("get-join-linq")]
        public async Task<IActionResult> GetJoinLinq()
        {
            var angajati = await _adapostManager.GetJoinLinq();
            return Ok(angajati);
        }

        /*[HttpGet("get-group-by")]
        public async Task<IActionResult> GetGroupBy()
        {
            try
            {
                var grouped = _context.AdapostAsociaties.GroupBy(x => x.AdapostId).Select(x => new
                {
                    Key = x.Key,
                    Average = x.Average(y => y.SumaDonata)
                });

                return Ok(grouped);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
        
        [HttpGet("get-join-linq")]
        public async Task<IActionResult> GetJoinLinq()
        {
            try
            {
                var angajati = _context.Employeers;
                var join = _context.Adaposts
                    .Join(angajati, b => b.Id, a => a.AdapostId, (b, a) => new 
                    {               
                        a.AdapostId,
                        b.Nume,
                        a.Id,
                        a.Prenume,
                        a.Salariu
                    });

                return Ok(join);
            }
            catch (Exception ex)
            {
                return BadRequest(ex); 
            }
        } */

    }
}
