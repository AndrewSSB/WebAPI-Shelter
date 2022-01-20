using AdapostAPI.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapostAPI.DAL.Interfaces
{
    public interface IAngajatRepository
    {
        Task Create(Employeer angajat);
        Task Update(Employeer angajat);
        Task Delete(int id);
        Task<List<Employeer>> GetAll();
        Task<Employeer> GetById(int id);
    }
}
