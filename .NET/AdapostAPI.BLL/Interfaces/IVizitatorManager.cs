using AdapostAPI.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapostAPI.BLL.Interfaces
{
    public interface IVizitatorManager
    {
        Task Create(Vizitator vizitator);
        Task Update(Vizitator vizitator);
        Task Delete(int id);
        Task<List<Vizitator>> GetAll();
        Task<Vizitator> GetById(int id);
    }
}
