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
    public class ViziteManager : IViziteManager
    {
        private readonly IAdapostVizitatorRepository _vizite;
        public ViziteManager(IAdapostVizitatorRepository vizite)
        {
            _vizite = vizite;
        }

        public async Task Create(AdapostVizitator adapostVizitator)
        {
            await _vizite.Create(adapostVizitator);
        }

        public async Task Delete(int id)
        {
            await _vizite.Delete(id);
        }

        public async Task<List<AdapostVizitator>> GetAll()
        {
            var vizite = await _vizite.GetAll();
            return vizite;
        }

        public async Task<AdapostVizitator> GetById(int id)
        {
            var vizita = await _vizite.GetById(id);
            return vizita;
        }

        public async Task Update(AdapostVizitator adapostVizitator)
        {
            await _vizite.Update(adapostVizitator);
        }
    }
}
