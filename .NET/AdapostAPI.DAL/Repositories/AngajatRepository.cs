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
    public class AngajatRepository : IAngajatRepository
    {
        private readonly AppDbContext _context;

        public AngajatRepository (AppDbContext context)
        {
            _context = context; //dependecy injection
        }

        public async Task Create(Employeer angajat)
        {
            await _context.Employeers.AddAsync(angajat);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var angajat = await _context.Employeers.FirstOrDefaultAsync(x => x.Id == id);
            _context.Employeers.Remove(angajat);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Employeer>> GetAll()
        {
            var angajat = await _context.Employeers.ToListAsync();
            return angajat;
        }

        public async Task<Employeer> GetById(int id)
        {
            var angajat = await _context.Employeers.FirstOrDefaultAsync(x => x.Id == id);
            return angajat;
        }

        public async Task Update(Employeer animal)
        {
            _context.Employeers.Update(animal);
            await _context.SaveChangesAsync();
        }
    }
}
