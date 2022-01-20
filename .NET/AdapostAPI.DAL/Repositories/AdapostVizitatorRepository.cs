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
    public class AdapostVizitatorRepository : IAdapostVizitatorRepository
    {
        private readonly AppDbContext _context;
        public AdapostVizitatorRepository (AppDbContext context)
        {
            _context = context; //dependecy injection
        }

        public async Task Create(AdapostVizitator obj)
        {
            await _context.AdapostVizitators.AddAsync(obj);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var adoptanti = await _context.AdapostVizitators.FirstOrDefaultAsync(x => x.Id == id);
            _context.AdapostVizitators.Remove(adoptanti);
            await _context.SaveChangesAsync();
        }

        public async Task<List<AdapostVizitator>> GetAll()
        {
            var adoptanti = await _context.AdapostVizitators.ToListAsync();
            return adoptanti;
        }

        public async Task<AdapostVizitator> GetById(int id)
        {
            var adoptanti = await _context.AdapostVizitators.FirstOrDefaultAsync(x => x.Id == id);
            return adoptanti;
        }

        public async Task Update(AdapostVizitator obj)
        {
            _context.AdapostVizitators.Update(obj);
            await _context.SaveChangesAsync();
        }
    }
}
