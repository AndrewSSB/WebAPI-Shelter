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
    public class AngajatManager : IAngajatManager
    {
        private readonly IAngajatRepository _angajatRepository;
        public AngajatManager(IAngajatRepository angajatRepository)
        {
            _angajatRepository = angajatRepository;
        }

        public async Task Create(Employeer employeer)
        {
            await _angajatRepository.Create(employeer);
        }

        public async Task Delete(int id)
        {
            await _angajatRepository.Delete(id);
        }

        public async Task<List<Employeer>> GetAll()
        {
            var angajati = await _angajatRepository.GetAll();
            return angajati;
        }

        public async Task<Employeer> GetById(int id)
        {
            var angajat = await _angajatRepository.GetById(id);
            return angajat;
        }

        public async Task Update(Employeer employeer)
        {
            await _angajatRepository.Update(employeer);
        }
    }
}
