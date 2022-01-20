using AdapostAPI.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapostAPI.BLL.Interfaces
{
    public interface ILocationManager
    {
        Task Create(Location location);
        Task Update(Location location);
        Task Delete(int id);
        Task<List<Location>> GetAll();
        Task<Location> GetById(int id);
    }
}
