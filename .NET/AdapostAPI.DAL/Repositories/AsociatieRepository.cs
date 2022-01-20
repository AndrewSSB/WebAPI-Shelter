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
    public class AsociatieRepository : IAsociatieRepository
    {
        private readonly AppDbContext _context;

        public AsociatieRepository(AppDbContext context)
        {
            _context = context; //dependecy injection
        }

        public async Task Create(Asociatie asociatie)
        {
            await _context.Asociaties.AddAsync(asociatie);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var adoptanti = await _context.Asociaties.FirstOrDefaultAsync(x => x.Id == id);
            _context.Asociaties.Remove(adoptanti);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Asociatie>> GetAll()
        {
            var adoptanti = await _context.Asociaties.ToListAsync();
            return adoptanti;
        }

        public async Task<Asociatie> GetById(int id)
        {
            var adoptanti = await _context.Asociaties.FirstOrDefaultAsync(x => x.Id == id);
            return adoptanti;
        }

        public async Task Update(Asociatie asociatie)
        {
            _context.Asociaties.Update(asociatie);
            await _context.SaveChangesAsync();
        }
    }
}
