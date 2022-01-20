using AdapostAPI.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapostAPI.DAL.Interfaces
{
    public interface IAdapostVizitatorRepository
    {
        Task Create(AdapostVizitator obj);
        Task Update(AdapostVizitator obj);
        Task Delete(int id);
        Task<List<AdapostVizitator>> GetAll();
        Task<AdapostVizitator> GetById(int id);
    }
}
