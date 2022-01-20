using AdapostAPI.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapostAPI.DAL.Interfaces
{
    public interface IAdoptantRepository
    {
        Task Create(Adoptanti adoptant);
        Task Update(Adoptanti adoptant);
        Task Delete(int id);
        Task<List<Adoptanti>> GetAll();
        Task<Adoptanti> GetById(int id);
    }
}
