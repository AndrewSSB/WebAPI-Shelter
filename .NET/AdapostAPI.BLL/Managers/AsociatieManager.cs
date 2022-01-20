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
    public class AsociatieManager : IAsociatieManager
    {
        private readonly IAsociatieRepository _asociatieRepository;
        public AsociatieManager(IAsociatieRepository asociatieRepository)
        {
            _asociatieRepository = asociatieRepository;
        }
        public async Task Create(Asociatie asociatie)
        {
            await _asociatieRepository.Create(asociatie);
        }

        public async Task Delete(int id)
        {
            await _asociatieRepository.Delete(id);
        }

        public async Task<List<Asociatie>> GetAll()
        {
            var asociatii = await _asociatieRepository.GetAll();
            return asociatii;
        }

        public async Task<Asociatie> GetById(int id)
        {
            var asociatie = await _asociatieRepository.GetById(id);
            return asociatie;
        }

        public async Task Update(Asociatie asociatie)
        {
            await _asociatieRepository.Update(asociatie);
        }
    }
}
