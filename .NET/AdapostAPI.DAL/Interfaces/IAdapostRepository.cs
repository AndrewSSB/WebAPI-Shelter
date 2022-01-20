using AdapostAPI.DAL.Entities;
using AdapostAPI.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapostAPI.DAL.Interfaces
{
    public interface IAdapostRepository
    {
        Task Create(Adapost adapost);
        Task Update(Adapost adapost);
        Task Delete(int id);
        Task<List<Adapost>> GetAll(); //returneaza toate adaposturile
        Task<Adapost> GetById(int id); //returneaza un adapost dupa id-ul introdus
        Task<AdapostModel> GetByIdModel(int id);
        Task<List<SponsorizareModel>> GetByGroup();
        Task<List<AngajatModel>> GetJoinLinq();
    }
}
