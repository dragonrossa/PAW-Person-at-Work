using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RadniSati.Models
{
    public class Projekt
    {
        public int Sifra { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public string PM { get; set; }
        public string Klijent { get; set; }

        public Projekt(int sifra, string naziv, string opis, string pm, string klijent)
        {
            this.Sifra = sifra;
            this.Naziv = naziv;
            this.Opis = opis;
            this.PM = pm;
            this.Klijent = klijent;
        }


        public Projekt(int sifra, string naziv)
        {
            this.Sifra = sifra;
            this.Naziv = naziv;
        }

    }
}