using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RadniSati.Models
{
    public class Sati
    {
        public int SifraZaposlenika
        { get; set; }
        public string ImeZaposlenika
        { get; set; }
        public string PrezimeZaposlenika
        { get; set; }
        public int Ulazak
        { get; set; }
        public int Izlazak
        { get; set; }
        public int Razlika
        { get; set; }
        public int Visak
        { get; set; }

        public Sati(/*int sifra, string ime, string prezime,*/ int ulazak, int izlazak)
        {
            //this.SifraZaposlenika = sifra;
            //this.ImeZaposlenika = ime;
            //this.PrezimeZaposlenika = prezime;
            this.Ulazak = ulazak;
            this.Izlazak = izlazak;

        }

        public Sati()
        {
                
        }
    }
}