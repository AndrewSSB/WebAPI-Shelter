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
    public class AdapostAsociatieRepository : IAdapostAsociatieRepository
    {
        private readonly AppDbContext _context;
        public AdapostAsociatieRepository(AppDbContext context)
        {
            _context = context; //dependecy injection
        }
        public async Task Create(AdapostAsociatie obj)
        {
            await _context.AdapostAsociaties.AddAsync(obj);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var adoptanti = await _context.AdapostAsociaties.FirstOrDefaultAsync(x => x.Id == id);
            _context.AdapostAsociaties.Remove(adoptanti);
            await _context.SaveChangesAsync();
        }

        public async Task<List<AdapostAsociatie>> GetAll()
        {
            var adoptanti = await _context.AdapostAsociaties.ToListAsync();
            return adoptanti;
        }

        public async Task<AdapostAsociatie> GetById(int id)
        {
            var adoptanti = await _context.AdapostAsociaties.FirstOrDefaultAsync(x => x.Id == id);
            return adoptanti;
        }

        public async Task Update(AdapostAsociatie obj)
        {
            _context.AdapostAsociaties.Update(obj);
            await _context.SaveChangesAsync();
        }
    }
}
