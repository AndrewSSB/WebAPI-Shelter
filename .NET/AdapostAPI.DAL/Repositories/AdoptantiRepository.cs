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
    public class AdoptantiRepository : IAdoptantRepository
    {
        private readonly AppDbContext _context;

        public AdoptantiRepository (AppDbContext context)
        {
            _context = context; //dependecy injection
        }

        public async Task Create(Adoptanti adoptant)
        {
            await _context.Adoptantis.AddAsync(adoptant);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var adoptanti = await _context.Adoptantis.FirstOrDefaultAsync(x => x.Id == id);
            _context.Adoptantis.Remove(adoptanti);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Adoptanti>> GetAll()
        {
            var adoptanti = await _context.Adoptantis.ToListAsync();
            return adoptanti;
        }

        public async Task<Adoptanti> GetById(int id)
        {
            var adoptanti = await _context.Adoptantis.FirstOrDefaultAsync(x => x.Id == id);
            return adoptanti;
        }

        public async Task Update(Adoptanti adoptant)
        {
            _context.Adoptantis.Update(adoptant);
            await _context.SaveChangesAsync();
        }
    }
}
