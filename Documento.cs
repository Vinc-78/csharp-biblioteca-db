using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca_db
{
    public enum Stato { Disponibile, Prestito }
    public class Documento
    {
        public string Codice { get; set; }
        public string Titolo { get; set; }
        public int Anno { get; set; }
        public string Settore { get; set; }
        public Stato Stato { get; set; }
        public List<Autore> Autori { get; set; }
        public Scaffale Scaffale { get; set; }

        public Documento(string Codice, string Titolo, int Anno, string Settore, string nomeSCaffale)
        {
            this.Codice = Codice;
            this.Titolo = Titolo;
            this.Settore = Settore;
            this.Autori = new List<Autore>();
            this.Stato = Stato.Disponibile;
            this.Scaffale = new Scaffale(nomeSCaffale);
        }

        public override string ToString()
        {
            return string.Format("Codice:{0}\nTitolo:{1}\nSettore:{2}\nStato:{3}\nScaffale numero:{4}",
                this.Codice,
                this.Titolo,
                this.Settore,
                this.Stato,
                this.Scaffale.Numero);
        }

        public void ImpostaInPrestito()
        {
            this.Stato = Stato.Prestito;
        }

        public void ImpostaDisponibile()
        {
            this.Stato = Stato.Disponibile;
        }
    }
}
