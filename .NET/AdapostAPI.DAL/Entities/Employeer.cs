using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapostAPI.DAL.Entities
{
    public class Employeer
    {
        [Key]
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public DateTime DataAngajarii { get; set; }
        public string Post { get; set; }
        public decimal Salariu { get; set; }
        public int AdapostId { get; set; }
        public virtual Adapost Adapost { get; set; }
    }
}
