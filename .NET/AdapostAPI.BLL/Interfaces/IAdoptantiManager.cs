using AdapostAPI.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapostAPI.BLL.Interfaces
{
    public interface IAdoptantiManager
    {
        Task Create(Adoptanti adoptanti);
        Task Update(Adoptanti adoptanti);
        Task Delete(int id);
        Task<List<Adoptanti>> GetAll();
        Task<Adoptanti> GetById(int id);
    }
}
