using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RadniSati.Models
{
    public class Zaposlenici
    {
        public int BrojZaposlenik { get; set; }
        //public int BrojZaposlenikaIzZagreba { get; set; }

        public int SifraZaposlenika { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Adresa { get; set; }
        public int PostanskiBroj { get; set; }
        public string Grad { get; set; }
        public string Mail { get; set; }
        public int Mobitel { get; set; }
        public int Telefon { get; set; }
        public string Lokacija { get; set; }
        public string Odjel { get; set; }
        public string RadnaPozicija { get; set; }
        public bool LoginZap { get; set; }
        public int SifraProjekta { get; set; }
        public string Ostalo;

        public Zaposlenici(int sifraZaposlenika, string ime, string prezime, string adresa, int postanskiBroj,
    string grad, string mail, int mobitel, int telefon,
    string lokacija, string odjel,
    string radnaPozicija, bool loginZap, int sifraProjekta, string ostalo)
        {
            this.SifraZaposlenika = sifraZaposlenika;
            this.Ime = ime;
            this.Prezime = prezime;
            this.Adresa = adresa;
            this.PostanskiBroj = postanskiBroj;
            this.Grad = grad;
            this.Mail = mail;
            this.Mobitel = mobitel;
            this.Telefon = telefon;
            this.Lokacija = lokacija;
            this.Odjel = odjel;
            this.RadnaPozicija = radnaPozicija;
            this.LoginZap = loginZap;
            this.SifraProjekta = sifraProjekta;
            this.Ostalo = ostalo;
        }

        public Zaposlenici(int sifraZaposlenika, string ime, string prezime)
        {
            this.SifraZaposlenika = sifraZaposlenika;
            this.Ime = ime;
            this.Prezime = prezime;
        }

        public Zaposlenici(int broj/*, int broj2*/)
        {
            this.BrojZaposlenik = broj;
            //this.BrojZaposlenikaIzZagreba = broj2;
        }

        
    }
}