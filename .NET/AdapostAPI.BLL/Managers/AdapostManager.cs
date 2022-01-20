using AdapostAPI.BLL.Interfaces;
using AdapostAPI.DAL.Entities;
using AdapostAPI.DAL.Interfaces;
using AdapostAPI.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapostAPI.BLL.Managers
{
    public class AdapostManager : IAdapostManager
    {
        private readonly IAdapostRepository _adapostRepo;
        public AdapostManager(IAdapostRepository adapostRepo)
        {
            _adapostRepo = adapostRepo;
        }

        public async Task<string> AdapostDetails(int id)
        {
            var adapost = await _adapostRepo.GetByIdModel(id);
            string adap = $"Nume: {adapost.NumeAdapost}" +
                $"\nIdAdapost: {adapost.IdAdapost}" +
                $"\nEmail: {adapost.EmailAdapost}" +
                $"\nTelefon: {adapost.TelefonAdapost}" +
                $"\nLocatie: {adapost.IdLocatie}";
            return adap;
        }

        public async Task Create(Adapost adapost)
        {
            await _adapostRepo.Create(adapost);
        }

        public async Task Delete(int id)
        {
            await _adapostRepo.Delete(id);
        }

        public async Task<List<Adapost>> GetAll()
        {
            var adaposts = await _adapostRepo.GetAll();
            return adaposts;
        }

        public async Task<List<string>> GetByGroup()
        {
            var groupBy = await _adapostRepo.GetByGroup();

            var strings = new List<string>();

            foreach(var i in groupBy)
            {
                strings.Add($"Id adapost: {i.Id}, Suma donata: {i.SumaDonata}");
            }

            return strings;
        }

        public async Task<Adapost> GetById(int id)
        {
            var adapost = await _adapostRepo.GetById(id);
            return adapost;
        }

        public async Task<List<AngajatModel>> GetJoinLinq()
        {
            var angajati = await _adapostRepo.GetJoinLinq();
            return angajati;
        }

        public async Task<List<string>> GetNumeSiIdAdapost()
        {
            var adaposts = await _adapostRepo.GetAll();
            var strings = new List<string>();
            foreach(var adapost in adaposts)
            {
                var adapostModel = new AdapostModel
                {
                    NumeAdapost = adapost.Nume,
                    IdAdapost = adapost.Id,
                };
                strings.Add($"Adapost id:{adapostModel.IdAdapost}, Nume adapost: {adapostModel.NumeAdapost}");
            }

            return strings;
        }

        public async Task Update(Adapost adapost)
        {
            await _adapostRepo.Update(adapost);
        }
    }
}
