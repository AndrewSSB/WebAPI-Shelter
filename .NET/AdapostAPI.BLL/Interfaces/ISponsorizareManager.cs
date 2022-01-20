using AdapostAPI.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapostAPI.BLL.Interfaces
{
    public interface ISponsorizareManager
    {
        Task Create(AdapostAsociatie adapostAsociatie);
        Task Update(AdapostAsociatie adapostAsociatie);
        Task Delete(int id);
        Task<List<AdapostAsociatie>> GetAll();
        Task<AdapostAsociatie> GetById(int id);
    }
}
