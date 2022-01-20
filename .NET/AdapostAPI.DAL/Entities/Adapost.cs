using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapostAPI.DAL.Entities
{
    public class Adapost
    {
        [Key]
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<Employeer> Employeers { get; set; }
        public virtual ICollection<Animal> Animals { get; set; }
        public virtual ICollection<AdapostVizitator> AdapostVizitators { get; set; }
        public virtual ICollection<AdapostAsociatie> AdapostAsociaties { get; set; }
    }
}
