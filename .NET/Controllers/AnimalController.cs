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
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalManager _animalManager;

        public AnimalController(IAnimalManager animalManager)
        {
            _animalManager = animalManager;
        }

        [HttpPost("AddAnimal")]
        [Authorize("Admin")]
        public async Task<IActionResult> AddAnimal([FromBody] Animal animal)
        {
            await _animalManager.Create(animal);
            return Ok();
        }

        [HttpGet("GetAnimal/{id}")]
        
        public async Task<IActionResult> GetAnimal([FromRoute] int id)
        {
            //var adapost = await _context.Adaposts.FirstOrDefaultAsync(x => x.Id == id); // prima metoda de accesare
            var animal = await _animalManager.GetById(id);
            if (animal != null)
            {
                return Ok(animal);
            }
            return BadRequest("Id-ul introdus este incorect.");
        }

        [HttpGet("GetAnimals")]
        //[Authorize("Admin")] // bearer + token (postman)
        public async Task<IActionResult> GetAnimals()
        {
            var animals = await _animalManager.GetAll();
            if (animals != null)
            {
                return Ok(animals);
            }

            return BadRequest("Nu exista niciun adapost.");
        }

        [HttpPut("UpdateAnimal")]
        [Authorize("Admin")]
        public async Task<IActionResult> UpdateAnimal([FromBody] Animal animal)
        {
            await _animalManager.Update(animal);
            return Ok();
        }

        [HttpDelete("DeleteAnimal")]
        [Authorize("Admin")]
        public async Task<IActionResult> DeleteAnimal([FromQuery] int id)
        {
            await _animalManager.Delete(id);
            return Ok();
        }

        [HttpGet("ListaAnimaleWhere")]
        public async Task<IActionResult> ListaAnimaleWhere()
        {
            var animals = await _animalManager.AnimaleAdoptate();
            return Ok(animals);
        }

        [HttpGet("ListaAnimaleJoin")]
        public async Task<IActionResult> ListaAnimaleJoin()
        {
            var animals = await _animalManager.AnimalJoin();
            return Ok(animals);
        }

        [HttpGet("ListaAdoptantiOrderBy")]
        public async Task<IActionResult> ListaAdoptantiOrderBy()
        {
            var adoptanti = await _animalManager.OrderBy();
            return Ok(adoptanti);
        }

        [HttpGet("GetAnimalsById")]
        public async Task<IActionResult> GetAnimalsById([FromQuery] int id)
        {
            var animals = await _animalManager.GetAnimalsById(id);
            return Ok(animals);
        }

        /*[HttpPut("UpdateAdoptanti")]
        public async Task<IActionResult> AddAdoptantiToAnimals([FromQuery] int id, int idAdoptant)
        {
            //var checkAdoptanti = await _animal.Adoptantis.AsNoTracking().FirstOrDefaultAsync(x => x.Id == idAdoptant); //sa nu mai trackuiasca
            var actualizareAdoptanti = await _animal.Animals.FindAsync(id);
            var checkAdoptanti = await _animal.Adoptantis.FindAsync(idAdoptant);

            if (checkAdoptanti != null && actualizareAdoptanti != null)
            {
                actualizareAdoptanti.AdoptantiId = idAdoptant;

                //_animal.Animals.Attach(actualizareAdoptanti); //il atasam 
                await _animal.SaveChangesAsync();

                return Ok();
            }

            return BadRequest("Id-urile introduse sunt incorecte");
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteAnimalFromDb([FromRoute] int id)
        {
            var idAnimal = await _animal.Animals.FindAsync(id);

            if (idAnimal != null)
            {              
                _animal.Animals.Remove(idAnimal);
                await _animal.SaveChangesAsync();
                return Ok();
            }

            return BadRequest("Id-ul introdus nu exista.");
        }

        [HttpGet("GetAnimal/{id}")]
        public async Task<IActionResult> GetAnimal([FromRoute] int id)
        {
            var animal = await _animal.Animals.FirstOrDefaultAsync(x => x.Id == id);

            if (animal != null)
            {
                return Ok(animal);
            }

            return BadRequest("Id-ul introdus nu exista.");
        }

        [HttpGet("GetAnimals")]
        public async Task<IActionResult> GetAnimals() 
        {
            var animals = await _animal.Animals.ToListAsync();

            return Ok(animals);
        }

        [HttpGet("GetAnimals-select-id-where")]
        public async Task<IActionResult> GetAnimalsId()
        {
            var animals = await _animal.Animals
                .Where(x => x.AdoptantiId != null)
                .Select(x => new { Id = x.Id, Specie = x.Specie })
                .ToListAsync();

            return Ok(animals);
        }
        
        [HttpGet("GetAnimalsJoin")]
        public async Task<IActionResult> GetAnimalsJoin()
        {
            var animalsWithAdoptanti = await _animal
                .Animals
                .Include(x => x.Adoptanti)
                .Select(x => new { AnimalId = x.Id, AdoptantiNume = x.Adoptanti.Nume, AdoptantiPren = x.Adoptanti.Prenume })
                .ToListAsync();

            return Ok(animalsWithAdoptanti);
        }

        [HttpGet("Get-Animals-join-where")]
        public async Task<IActionResult> GetAnimalsJoinWhere()
        {
            var animals = await _animal
                .Adaposts
                .Include(x => x.Animals)
                .Where(x => x.Animals.Count > 1)
                .ToListAsync();

            return Ok(animals);
        }
        
        [HttpGet("order-by")]
        public async Task<IActionResult> GetAnimalOrderBy()
        {
            var animals = await _animal
                .Adoptantis
                .Include(x => x.Animal)
                .Where(x => x.Animal.Count > 1)
                .OrderBy(x => x.Id)
                .ToListAsync();

            return Ok(animals);
        } */
    }
}
