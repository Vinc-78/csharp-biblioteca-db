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
                case 1: //Da implementare i controlli nell'inserimento e conversione in int
                        //e aggiornare repo su Vinc-78

                    Console.WriteLine("inserisci i dati o l'inserimento non funziona");
                    Console.WriteLine("inserisci nome autore :");
                    string nomeAutore = Console.ReadLine();
                    Console.WriteLine("inserisci cognome autore :");
                    string cognomeAutore = Console.ReadLine();
                    Console.WriteLine("inserisci email autore :");
                    string emailAutore = Console.ReadLine();
                    Console.WriteLine("-------------------");
                    Console.WriteLine("inserisci codice libro :");
                    string scodiceLibro = Console.ReadLine();
                    int codiceLibro = Int32.Parse(scodiceLibro);
                    Console.WriteLine("inserisci titolo libro :");
                    string titoloLibro = Console.ReadLine();
                    Console.WriteLine("inserisci settore libro :");
                    string settoreLibro = Console.ReadLine();
                    Console.WriteLine("inserisci numero pagine libro :");
                    string spagLibro = Console.ReadLine();
                    int pagLibro = Int32.Parse(spagLibro);
                    Console.WriteLine("inserisci numero scaffale libro :");
                    string scaffaleLibro = Console.ReadLine();


                    Biblioteca b = new Biblioteca("Civica");
                    List<Autore> lAutoriLibro = new List<Autore>();
                    Autore AutoreMioLibro = new Autore(nomeAutore,cognomeAutore,emailAutore);
                    lAutoriLibro.Add(AutoreMioLibro);
                    b.AggiungiLibro(codiceLibro, titoloLibro, settoreLibro, pagLibro, scaffaleLibro, lAutoriLibro);

                    Console.WriteLine("----------------------");
                    Console.WriteLine("dati inseriti correttamente");
                    
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
