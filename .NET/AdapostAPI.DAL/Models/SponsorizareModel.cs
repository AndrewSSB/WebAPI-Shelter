using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapostAPI.DAL.Models
{
    public class SponsorizareModel
    {
        public int Id { get; set; }
        public int AdapostId { get; set; }
        public int AsociatieId { get; set; }
        public decimal SumaDonata { get; set; }
    }
}
