using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapostAPI.DAL.Models
{
    public class AdapostModel
    {
        public int IdAdapost { get; set; }
        public string NumeAdapost { get; set; }
        public string EmailAdapost { get; set; }
        public string TelefonAdapost { get; set; }
        public int IdLocatie { get; set; }
    }
}
