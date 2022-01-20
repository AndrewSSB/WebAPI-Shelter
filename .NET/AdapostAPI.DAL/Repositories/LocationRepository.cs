using AdapostAPI.DAL.Entities;
using AdapostAPI.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapostAPI.DAL.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly AppDbContext _context;

        public LocationRepository (AppDbContext context)
        {
            _context = context; //dependecy injection
        }

        public async Task Create(Location locatie)
        {
            await _context.Locations.AddAsync(locatie);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var locatie = await _context.Locations.FirstOrDefaultAsync(x => x.Id == id);
            _context.Locations.Remove(locatie);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Location>> GetAll()
        {
            var locations = await _context.Locations.ToListAsync();
            return locations;
        }

        public async Task<Location> GetById(int id)
        {
            var locatie = await _context.Locations.FirstOrDefaultAsync(x => x.Id == id);
            return locatie;
        }

        public async Task Update(Location locatie)
        {
            _context.Locations.Update(locatie);
            await _context.SaveChangesAsync();
        }
    }
}
