using AdapostAPI.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapostAPI.BLL.Interfaces
{
    public interface IAsociatieManager
    {
        Task Create(Asociatie asociatie);
        Task Update(Asociatie asociatie);
        Task Delete(int id);
        Task<List<Asociatie>> GetAll();
        Task<Asociatie> GetById(int id);
    }
}
