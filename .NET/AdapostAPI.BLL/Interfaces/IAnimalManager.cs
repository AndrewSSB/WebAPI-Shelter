using AdapostAPI.DAL.Entities;
using AdapostAPI.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapostAPI.BLL.Interfaces
{
    public interface IAnimalManager
    {
        Task Create(Animal animal);
        Task Update(Animal animal);
        Task Delete(int id);
        Task<List<Animal>> GetAll();
        Task<Animal> GetById(int id);
        Task<List<string>> AnimaleAdoptate();
        Task<List<string>> AnimalJoin();
        Task<List<Adoptanti>> OrderBy();
        Task<List<Animal>> GetAnimalsById(int id);
    }
}
