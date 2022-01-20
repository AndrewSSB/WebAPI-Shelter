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
    public class VizitatorManager : IVizitatorManager
    {
        private readonly IVizitatorRepository _vizitatorRepo;
        public VizitatorManager(IVizitatorRepository vizitatorRepo)
        {
            _vizitatorRepo = vizitatorRepo;
        }

        public async Task Create(Vizitator vizitator)
        {
            await _vizitatorRepo.Create(vizitator);
        }

        public async Task Delete(int id)
        {
            await _vizitatorRepo.Delete(id);
        }

        public async Task<List<Vizitator>> GetAll()
        {
            var vizitatori = await _vizitatorRepo.GetAll();
            return vizitatori;
        }

        public async Task<Vizitator> GetById(int id)
        {
            var vizitator = await _vizitatorRepo.GetById(id);
            return vizitator;
        }

        public async Task Update(Vizitator vizitator)
        {
            await _vizitatorRepo.Update(vizitator);
        }
    }
}
