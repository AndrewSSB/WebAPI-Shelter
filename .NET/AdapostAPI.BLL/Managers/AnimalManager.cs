using AdapostAPI.BLL.Interfaces;
using AdapostAPI.DAL.Entities;
using AdapostAPI.DAL.Interfaces;
using AdapostAPI.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapostAPI.BLL.Managers
{
    public class AnimalManager : IAnimalManager
    {
        private readonly IAnimalRepository _animalRepo;
        public AnimalManager(IAnimalRepository animalRepo)
        {
            _animalRepo = animalRepo;
        }

        public async Task<List<string>> AnimaleAdoptate()
        {
            var animale = await _animalRepo.AnimalList();
            var aux = new List<string>();
            foreach(var animal in animale)
            {
                aux.Add($"Id: {animal.Id}" +
                    $" Data:{animal.DataInmatriculare}" +
                    $" Specie: {animal.Specie}" +
                    $" Adoptant: {animal.AdoptantiId}");
            }
            return aux;
        }

        public async Task<List<string>> AnimalJoin()
        {
            var strings = new List<string>();
            var animale = await _animalRepo.AnimalJoin();
            foreach(var animal in animale)
            {
                strings.Add($"Id animal: {animal.Id}, Specie: {animal.Specie}, Nume: {animal.NumeAdopt}, Prenume: {animal.PrenAdopt}");
            }

            return strings;
        }

        public async Task Create(Animal animal)
        {
            await _animalRepo.Create(animal);
        }

        public async Task Delete(int id)
        {
            await _animalRepo.Delete(id);
        }

        public async Task<List<Animal>> GetAll()
        {
            var animals = await _animalRepo.GetAll();
            return animals;
        }

        public async Task<List<Animal>> GetAnimalsById(int id)
        {
            var animals = await _animalRepo.GetAnimalsById(id);
            return animals;
     
        }

        public async Task<Animal> GetById(int id)
        {
            var animal = await _animalRepo.GetById(id);
            return animal;
        }

        public async Task<List<Adoptanti>> OrderBy()
        {
            /*var adoptanti = await _animalRepo.AnimalsOrderBy();
            var strings = new List<string>();
            foreach (var animal in adoptanti)
            {
                strings.Add($"Id animal: {animal.Id}, Nume: {animal.Nume}, Prenume: {animal.Prenume}");
            }

            return strings;*/

            var adoptanti = await _animalRepo.AnimalsOrderBy();
            return adoptanti;

        }

        public async Task Update(Animal animal)
        {
            await _animalRepo.Update(animal);
        }
    }
}
