using AdapostAPI.DAL.Entities;
using AdapostAPI.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapostAPI.BLL.Interfaces
{
    public interface IAdapostManager
    {
        Task<List<string>> GetNumeSiIdAdapost();
        Task<string> AdapostDetails(int id);
        Task Create(Adapost adapost);
        Task Update(Adapost adapost);
        Task Delete(int id);
        Task<List<Adapost>> GetAll();
        Task<Adapost> GetById(int id);
        Task<List<string>> GetByGroup();
        Task<List<AngajatModel>> GetJoinLinq();
    }
}
