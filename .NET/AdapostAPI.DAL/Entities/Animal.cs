using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapostAPI.DAL.Entities
{
    public class Animal
    {
        [Key]
        public int Id { get; set; }
        public DateTime DataInmatriculare { get; set; }
        public string Specie { get; set; }
        public decimal Greutate { get; set; }
        public decimal Inaltime { get; set; }
        public int varsta { get; set; }
        public char Sex { get; set; }
        public int AdapostId { get; set; }
        public int? AdoptantiId { get; set; } = null;
        public virtual Adapost Adapost { get; set; }
        public virtual Adoptanti Adoptanti { get; set; }
    }
}
