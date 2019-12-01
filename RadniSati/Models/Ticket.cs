using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RadniSati.Models
{
    public class Ticket
    {
        public int SifraTicket { get; set; }
        public string Naslov { get; set; }
        public string Tip { get; set; }
        public string Status { get; set; }
        public string Komponenta { get; set; }
        public string Labela { get; set; }
        public string Asignee { get; set; }
        public string Reporter { get; set; }
        public DateTime DatumKreiranja { get; set; }
        public DateTime DatumZavrsetka { get; set; }
        public string Opis { get; set; }
        public int SifraZaposlenika { get; set; }
        public int SifraProjekta { get; set; }

    public Ticket(int sifraTicket, string naslov, string tip, string status, string komponenta,
    string labela, string asignee, string reporter, DateTime datumKreiranja,
    DateTime datumZavrsetka, string opis, int sifraZaposlenika, int sifraProjekta)
        {
            this.SifraTicket = sifraTicket;
            this.Naslov = naslov;
            this.Tip = tip;
            this.Status = status;
            this.Komponenta = komponenta;
            this.Labela = labela;
            this.Asignee = asignee;
            this.Reporter = reporter;
            this.DatumKreiranja = datumKreiranja;
            this.DatumZavrsetka = datumZavrsetka;
            this.Opis = opis;
            this.SifraZaposlenika = sifraZaposlenika;
            this.SifraProjekta = sifraProjekta;

        }
        
        public Ticket(int sifraTicket, string naslov)
        {
            this.SifraTicket = sifraTicket;
            this.Naslov = naslov;
        }

    }
}