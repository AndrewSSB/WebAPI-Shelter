using AdapostAPI.DAL.Entities;
using AdapostAPI.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapostAPI.DAL.Interfaces
{
    public interface IAnimalRepository
    {
        Task Create(Animal animal);
        Task Update(Animal animal);
        Task Delete(int id);
        Task<List<Animal>> GetAll();
        Task<Animal> GetById(int id);
        Task<List<AnimalModel>> AnimalList(); //ls
        Task<List<AnimalModel>> AnimalJoin();
        Task<List<Adoptanti>> AnimalsOrderBy();
        Task<List<Animal>> GetAnimalsById(int id);
    }
}
