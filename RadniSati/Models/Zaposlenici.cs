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

        public Zaposlenici(int broj/*, int broj2*/)
        {
            this.BrojZaposlenik = broj;
            //this.BrojZaposlenikaIzZagreba = broj2;
        }
    }
}