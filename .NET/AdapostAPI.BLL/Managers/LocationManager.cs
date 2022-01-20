using AdapostAPI.BLL.Interfaces;
using AdapostAPI.DAL.Entities;
using AdapostAPI.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapostAPI.BLL.Managers
{
    public class LocationManager : ILocationManager
    {
        private readonly ILocationRepository _locationRepository;
        public LocationManager(ILocationRepository locationManager)
        {
            _locationRepository = locationManager;
        }

        public async Task Create(Location location)
        {
            await _locationRepository.Create(location);
        }

        public async Task Delete(int id)
        {
            await _locationRepository.Delete(id);
        }

        public async Task<List<Location>> GetAll()
        {
            var locations = await _locationRepository.GetAll();
            return locations;
        }

        public async Task<Location> GetById(int id)
        {
            var location = await _locationRepository.GetById(id);
            return location;
        }

        public async Task Update(Location location)
        {
            await _locationRepository.Update(location);
        }
    }
}
