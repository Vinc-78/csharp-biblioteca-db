using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca_db
{
    public class Biblioteca
    {

        public string Nome { get; set; }
        public List<Scaffale>  ScaffaliBiblioteca { get; set; }
       

        public Biblioteca(string Nome)
        {
            this.Nome = Nome;
            this.ScaffaliBiblioteca = new List<Scaffale>();
            
        }

        public void AggiungiScaffale(string nomescaffale)

        {
            Scaffale nuovo = new Scaffale(nomescaffale);

            this.ScaffaliBiblioteca.Add(nuovo);
        }

        public int GestisciOperazioneBiblioteca(int iCodiceOperazione)
        {
            List<Documento> lResult;
            string sAppo;
            switch (iCodiceOperazione)
            {
                case 1:
                    Console.WriteLine("inserisci autore");
                    sAppo = Console.ReadLine();
                    lResult =SearchByAutore(sAppo);
                    if (lResult == null)
                        return 1;   //da implementare uscita da inserimento autore
                    else
                        StampaListaDocumenti(lResult);
                    break;

            }
            return 0;
        }


        public void StampaListaDocumenti(List<Documento> lListDoc)
        {
            // da implementare  
        }

        public List<Documento> SearchByCodice(string Codice)
        {
            Console.WriteLine("Metodo da implementare");
            return null;   
        }

        public List<Documento> SearchByTitolo(string Titolo)
        {
            Console.WriteLine("Metodo da implementare");
            return null;
            
        }

        public List<Documento> SearchByAutore(string Titolo)
        {
            Console.WriteLine("Metodo da implementare");

            // connetti al db
            // fare una query, quindi select titolo.scaffale, stato , tipo  from 
            // documenti, autori_documenti,  inner join
            // stampa 

            return null;

        }

        public List<Prestito> SearchPrestiti(string Numero)
        {
            Console.WriteLine("Metodo da implementare");
            return null;
        }

        public List<Prestito> SearchPrestiti(string Nome, string Cognome)
        {
            Console.WriteLine("Metodo da implementare");
            return null; ;
        }
    }
}
