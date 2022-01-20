using AdapostAPI.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapostAPI.DAL.Interfaces
{
    public interface ILocationRepository
    {
        Task Create(Location locatie);
        Task Update(Location locatie);
        Task Delete(int id);
        Task<List<Location>> GetAll();
        Task<Location> GetById(int id);
    }
}
