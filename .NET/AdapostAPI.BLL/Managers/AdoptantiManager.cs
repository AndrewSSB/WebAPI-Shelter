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
    public class AdoptantiManager : IAdoptantiManager
    {
        private readonly IAdoptantRepository _adoptantRepository;
        public AdoptantiManager(IAdoptantRepository adapostRepository)
        {
            _adoptantRepository = adapostRepository;
        }
        public async Task Create(Adoptanti adoptanti)
        {
            await _adoptantRepository.Create(adoptanti);
        }

        public async Task Update(Adoptanti adoptanti)
        {
            await _adoptantRepository.Update(adoptanti);
        }

        public async Task Delete(int id)
        {
            await _adoptantRepository.Delete(id);
        }

        public async Task<List<Adoptanti>> GetAll()
        {
            var adoptanti = await _adoptantRepository.GetAll();
            return adoptanti;
        }

        public async Task<Adoptanti> GetById(int id)
        {
            var adoptant = await _adoptantRepository.GetById(id);
            return adoptant;
        }

    }
}
