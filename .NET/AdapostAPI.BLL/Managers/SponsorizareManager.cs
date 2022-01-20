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
    public class SponsorizareManager : ISponsorizareManager
    {
        private readonly IAdapostAsociatieRepository _sponsorizare;
        public SponsorizareManager(IAdapostAsociatieRepository sponsorizare)
        {
            _sponsorizare = sponsorizare;
        }

        public async Task Create(AdapostAsociatie adapostAsociatie)
        {
            await _sponsorizare.Create(adapostAsociatie);
        }

        public async Task Delete(int id)
        {
            await _sponsorizare.Delete(id);
        }

        public async Task<List<AdapostAsociatie>> GetAll()
        {
            var sponsorizari = await _sponsorizare.GetAll();
            return sponsorizari;
        }

        public async Task<AdapostAsociatie> GetById(int id)
        {
            var sponsorizare = await _sponsorizare.GetById(id);
            return sponsorizare;
        }

        public async Task Update(AdapostAsociatie adapostAsociatie)
        {
            await _sponsorizare.Update(adapostAsociatie);
        }
    }
}
