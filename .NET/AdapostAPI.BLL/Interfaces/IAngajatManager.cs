using AdapostAPI.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapostAPI.BLL.Interfaces
{
    public interface IAngajatManager
    {
        Task Create(Employeer employeer);
        Task Update(Employeer employeer);
        Task Delete(int id);
        Task<List<Employeer>> GetAll();
        Task<Employeer> GetById(int id);
    }
}
