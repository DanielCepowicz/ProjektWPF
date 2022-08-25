using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biiblioteka
{
    public class plan_lekcji_bib
    {
        public int id_przedmiot { get; set; }
        public string nazwa { get; set; }
        public string dzien { get; set; }
        public string godzina { get; set; }
        public string link { get; set; }
    }
}
