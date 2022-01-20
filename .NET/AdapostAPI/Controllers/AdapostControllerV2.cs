using AdapostAPI.BLL.Interfaces;
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
    public class AdapostControllerV2 : ControllerBase
    {
        private readonly IAdapostManager _adapostManager;
        public AdapostControllerV2(IAdapostManager adapostManager)
        {
            _adapostManager = adapostManager;
        }

        [HttpGet("IdSiNume")]
        public async Task<IActionResult> IdSiNume()
        {
            var strings = await _adapostManager.GetNumeSiIdAdapost();
            return Ok(strings);
        }

        [HttpGet("AdapostDetails")]
        public async Task<IActionResult> GetAdapostDetails([FromQuery]int id)
        {
            var adapost = await _adapostManager.AdapostDetails(id);
            return Ok(adapost);
        }
    }
}
