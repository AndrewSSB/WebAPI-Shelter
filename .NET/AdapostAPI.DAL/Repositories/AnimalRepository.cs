using AdapostAPI.DAL.Entities;
using AdapostAPI.DAL.Interfaces;
using AdapostAPI.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapostAPI.DAL.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly AppDbContext _context;

        public AnimalRepository (AppDbContext context)
        {
            _context = context; //dependecy injection
        }

        public async Task<List<AnimalModel>> AnimalJoin()
        {
            var animalsWithAdoptanti = await _context
                .Animals
                .Where(x => x.AdoptantiId != null)
                .Include(x => x.Adoptanti)
                .Select(x => new { AnimalId = x.Id, Specie = x.Specie, AdoptantiNume = x.Adoptanti.Nume, AdoptantiPren = x.Adoptanti.Prenume })
                .ToListAsync();

            var animaleJoin = new List<AnimalModel>();
            foreach(var animal in animalsWithAdoptanti)
            {
                var aux = new AnimalModel
                {
                    Id = animal.AnimalId,
                    Specie = animal.Specie,
                    NumeAdopt = animal.AdoptantiNume,
                    PrenAdopt = animal.AdoptantiPren
                };
                animaleJoin.Add(aux);
            };
            return animaleJoin;
        }

        public async Task<List<AnimalModel>> AnimalList() //where
        {
            var animals = await _context.Animals
                .Where(x => x.AdoptantiId != null)
                .Select(x => new { Id = x.Id, Inmatriculare = x.DataInmatriculare, Specie = x.Specie, AdoptantId = x.AdoptantiId})
                .ToListAsync();

            var listaAnimale = new List<AnimalModel>();
            
            foreach(var animal in animals)
            {
                var aux = new AnimalModel
                {
                    Id = animal.Id,
                    Specie = animal.Specie,
                    DataInmatriculare = animal.Inmatriculare,
                    AdoptantiId = animal.AdoptantId
                };
                listaAnimale.Add(aux);
            }
            return listaAnimale;
        }

        public async Task<List<Adoptanti>> AnimalsOrderBy()
        {
            var animals = await _context
                .Adoptantis
                .Include(x => x.Animal)
                .Where(x => x.Animal.Count > 1)
                .OrderBy(x => x.Id)
                .ToListAsync();
            //var aux = new List<AdoptantModel>();
            
            /*foreach(var animal in animals)
            {
                var model = new AnimalModel
                {
                    Id = animal.Id,
                    NumeAdopt = animal.Nume,
                    PrenAdopt = animal.Prenume
                };
            } */
            return animals;
        }

        public async Task Create(Animal animal)
        {
            await _context.Animals.AddAsync(animal);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var animal = await _context.Animals.FirstOrDefaultAsync(x => x.Id == id);
            _context.Animals.Remove(animal);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Animal>> GetAll()
        {
            var animals = await _context.Animals.ToListAsync();
            return animals;
        }

        public async Task<List<Animal>> GetAnimalsById(int id)
        {
            var animals = await _context.Animals.Where(x => x.AdapostId == id).ToListAsync();
            return animals;
        }

        public async Task<Animal> GetById(int id)
        {
            var animal = await _context.Animals.FirstOrDefaultAsync(x => x.Id == id);
            return animal;
        }

        public async Task Update(Animal animal)
        {
            _context.Animals.Update(animal);
            await _context.SaveChangesAsync();
        }
    }
}
