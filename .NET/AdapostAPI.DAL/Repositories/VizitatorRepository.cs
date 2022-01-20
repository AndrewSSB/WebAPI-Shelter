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
    public class VizitatorRepository : IVizitatorRepository
    {
        private readonly AppDbContext _context;
        public VizitatorRepository(AppDbContext context)
        {
            _context = context; //dependecy injection
        }

        public async Task Create(Vizitator vizitator)
        {
            await _context.Vizitators.AddAsync(vizitator);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var adoptanti = await _context.Vizitators.FirstOrDefaultAsync(x => x.Id == id);
            _context.Vizitators.Remove(adoptanti);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Vizitator>> GetAll()
        {
            var adoptanti = await _context.Vizitators.ToListAsync();
            return adoptanti;
        }

        public async Task<Vizitator> GetById(int id)
        {
            var adoptanti = await _context.Vizitators.FirstOrDefaultAsync(x => x.Id == id);
            return adoptanti;
        }

        public async Task Update(Vizitator vizitator)
        {
            _context.Vizitators.Update(vizitator);
            await _context.SaveChangesAsync();
        }
    }
}
