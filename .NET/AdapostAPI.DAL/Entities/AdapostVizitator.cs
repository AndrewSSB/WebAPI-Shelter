using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapostAPI.DAL.Entities
{
    public class AdapostVizitator
    {
        public int Id { get; set; }
        public int AdapostId { get; set; }
        public int VizitatorId { get; set; }
        public DateTime DataVizitei { get; set; }
        public virtual Adapost Adapost { get; set; }
        public virtual Vizitator Vizitator { get; set; }
    }
}
