using AdapostAPI.DAL.Entities;
using AdapostAPI.DAL.Interfaces;
using AdapostAPI.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapostAPI.DAL.Repositories
{
    public class AdapostRepository : IAdapostRepository
    {
        private readonly AppDbContext _context;

        public AdapostRepository(AppDbContext context)
        {
            _context = context; //dependecy injection
        }

        public async Task Create(Adapost adapost)
        {
            await _context.Adaposts.AddAsync(adapost);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var adapost = await _context.Adaposts.FirstOrDefaultAsync(x => x.Id == id);
            _context.Adaposts.Remove(adapost);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Adapost>> GetAll()
        {
            var adaposts = await _context.Adaposts.ToListAsync();
            return adaposts;
        }

        public async Task<Adapost> GetById(int id)
        {
            var adapost = await _context.Adaposts.FirstOrDefaultAsync(x => x.Id == id);
            return adapost;
        }

        public async Task<AdapostModel> GetByIdModel(int id)
        {
            var adapost = await _context.Adaposts.FirstOrDefaultAsync(x => x.Id == id);
            if (adapost == null)
            {
                var text =  new AdapostModel();
                return text;
            }
            var adapostModel = new AdapostModel
            {
                NumeAdapost = adapost.Nume,
                IdAdapost = adapost.Id,
                TelefonAdapost = adapost.Telefon,
                EmailAdapost = adapost.Email,
                IdLocatie = adapost.LocationId
            };

            return adapostModel;

        }

        public async Task Update(Adapost adapost)
        {
            _context.Adaposts.Update(adapost);
            await _context.SaveChangesAsync();
        }

        public async Task<List<SponsorizareModel>> GetByGroup()
        {
            var grouped =  _context.AdapostAsociaties.GroupBy(x => x.AdapostId).Select(x => new
            {
                Key = x.Key,
                Average = x.Average(y => y.SumaDonata)
            });

            var _model = new List<SponsorizareModel>();

            foreach (var i in grouped)
            {
                var aux = new SponsorizareModel
                {
                    Id = i.Key,
                    SumaDonata = i.Average
                };
                _model.Add(aux);
            }

            return _model;
        }

        public async Task<List<AngajatModel>> GetJoinLinq()
        {
            var angajati = _context.Employeers;
            var join = _context.Adaposts
                .Join(angajati, b => b.Id, a => a.AdapostId, (b, a) => new
                {
                    a.AdapostId,
                    b.Nume,
                    a.Id,
                    a.Prenume,
                    a.Salariu
                });

            var angajatModel = new List<AngajatModel>();
            foreach(var i in join)
            {
                var aux = new AngajatModel
                {
                    Id = i.Id,
                    Nume = i.Nume,      
                    Prenume = i.Prenume,
                    Salariu = i.Salariu,
                    AdapostId = i.AdapostId
                };

                angajatModel.Add(aux);
            }

            return angajatModel;
        }
    }
}
