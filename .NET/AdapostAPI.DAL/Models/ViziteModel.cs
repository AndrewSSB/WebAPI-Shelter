using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapostAPI.DAL.Models
{
    public class ViziteModel
    {
        public int Id { get; set; }
        public int AdapostId { get; set; }
        public int VizitatorId { get; set; }
        public DateTime DataVizitei { get; set; }
    }
}
