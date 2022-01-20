using AdapostAPI.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapostAPI.DAL.Interfaces
{
    public interface IAdapostAsociatieRepository
    {
        Task Create(AdapostAsociatie obj);
        Task Update(AdapostAsociatie obj);
        Task Delete(int id);
        Task<List<AdapostAsociatie>> GetAll();
        Task<AdapostAsociatie> GetById(int id);
    }
}
