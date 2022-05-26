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

            List<string> elencoScaffali = DB.scaffaliGet();

            elencoScaffali.ForEach(item =>
            {
                Scaffale nuovo = new Scaffale(item);
                this.ScaffaliBiblioteca.Add(nuovo);
            });
            
        }

        public void AggiungiScaffale(string nomescaffale)

        {
            Scaffale nuovo = new Scaffale(nomescaffale);  //aggiunge alla lista
            this.ScaffaliBiblioteca.Add(nuovo);
            
            DB.scaffaleAdd(nomescaffale);    //aggiunge le righe dello scaffale nel db        
                
        }

        public void AggiungiLibro(int codice, string titolo, string settore, int pagine, string scaffale, List<Autore>listaAutori)
        {
            Libro MioLibro = new(codice,titolo, settore, pagine, scaffale);
            MioLibro.Stato = Stato.Disponibile;
            DB.libroAdd(MioLibro, listaAutori);
        
        }

        public int GestisciOperazioneBiblioteca(int iCodiceOperazione)
        {
            List<Documento> lResult;
            string sAppo;
            switch (iCodiceOperazione)
            {
                case 1: //Da modificare a seguito l'inserimento di Libro /Documento/ Autori in db
                    Console.WriteLine("inserisci autore");
                    sAppo = Console.ReadLine();
                    lResult =SearchByAutore(sAppo);
                    if (lResult == null)
                        return 1;   //da implementare uscita da inserimento autore
                    else
                        StampaListaDocumenti(lResult);
                    break;

                case 2:
                    Console.WriteLine("inserisci il codice dello scafalle tipo s000");
                    Console.WriteLine("clicca invio per uscire");
                    sAppo = Console.ReadLine();
                    if (sAppo != "") { AggiungiScaffale(sAppo); }
                    else { Console.WriteLine("non hai scritto nulla");
                        Environment.Exit(1);
                       
                    }
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
