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
        public string Task { get; set; }
        public string Rezultat { get; set; }
        public string Koordinator { get; set; }
        public DateTime Pocetak { get; set; }
        public DateTime Kraj { get; set; }
        public string Datum { get; set; }
        public string Budget { get; set; }
        public string Drzava { get; set; }
        public string ImeZaposlenika { get; set; }
        public string PrezimeZaposlenika { get; set; }

        public Projekt(int sifra, string naziv, string opis, string pm, string klijent, string task, string rezultat, string koordinator, DateTime pocetak, DateTime kraj, string datum, string budget, string drzava, string ime, string prezime)
        {
            this.Sifra = sifra;
            this.Naziv = naziv;
            this.Opis = opis;
            this.PM = pm;
            this.Klijent = klijent;
            this.Task = task;
            this.Rezultat = rezultat;
            this.Koordinator = koordinator;
            this.Pocetak = pocetak;
            this.Kraj = kraj;
            this.Datum = datum;
            this.Budget = budget;
            this.Drzava = drzava;
            this.ImeZaposlenika = ime;
            this.PrezimeZaposlenika = prezime;
        }



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