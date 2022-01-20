using AdapostAPI.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapostAPI.BLL.Interfaces
{
    public interface IViziteManager
    {
        Task Create(AdapostVizitator adapostVizitator);
        Task Update(AdapostVizitator adapostVizitator);
        Task Delete(int id);
        Task<List<AdapostVizitator>> GetAll();
        Task<AdapostVizitator> GetById(int id);
    }
}
