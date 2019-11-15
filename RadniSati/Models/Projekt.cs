using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RadniSati.Models
{
    public class Projekt
    {

        public string Naziv { get; set; }
        public string Opis { get; set; }
        public string PM { get; set; }
        public string Klijent { get; set; }

        public Projekt(string naziv, string opis, string pm, string klijent)
        {
            this.Naziv = naziv;
            this.Opis = opis;
            this.PM = pm;
            this.Klijent = klijent;
        }


    }
}