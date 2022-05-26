using System;

namespace csharp_biblioteca_db // Note: actual namespace depends on the project name.
{
    public class Program
    {
        static void Main(string[] args)
        {
            Biblioteca b = new Biblioteca("Civica");

           // b.AggiungiScaffale("s001"); dati già inseriti quindi ho commentato la riga
           // b.AggiungiScaffale("s002");
           // b.AggiungiScaffale("s003");

            b.ScaffaliBiblioteca.ForEach(item => Console.WriteLine(item.Numero));  //stampa la lista degli scaffali


            //passiamo all'inserimento dei libri e agli autori

            List<Autore> lAutoriLibro = new List<Autore>();

            Autore AutoreMioLibro = new Autore("Gianni","Rivera","email@email.it");

            lAutoriLibro.Add(AutoreMioLibro);


            b.AggiungiLibro(2, "Promessi Sposi", "Romanzo", 235, "s001", lAutoriLibro);



            // inizio parte dell'interfaccia

            Console.WriteLine("Lista operazione: ");
            Console.WriteLine("\t1 : cercaLibro per Autore ");
            Console.WriteLine("\t2 : Inserisci scaffale ");
            Console.WriteLine("Cosa vuoi fare ?");

            string sAppo = Console.ReadLine();

            while (sAppo != "")

            {
                if (sAppo == "1") b.GestisciOperazioneBiblioteca(1);
                else if (sAppo == "2") b.GestisciOperazioneBiblioteca(2);
            }

            /*

            #region "Libro 1"
            Libro l1 = new Libro("ISBN1", "Titolo 1", 2009, "Storia", 220);

            Autore a1 = new Autore("Nome 1", "Cognome 1");
            Autore a2 = new Autore("Nome 2", "Cognome 2");

          
            #endregion

            #region "Libro 2"
            Libro l2 = new Libro("ISBN2", "Titolo 2", 2009, "Storia", 130);

            Autore a3 = new Autore("Nome 3", "Cognome 3");
            Autore a4 = new Autore("Nome 4", "Cognome 4");

            l2.Autori.Add(a3);
            l2.Autori.Add(a4);

            l2.Scaffale = s2;
            
            #endregion

            #region "DVD"
            DVD dvd1 = new DVD("Codice1", "Titolo 3", 2019, "Storia", 130);

            dvd1.Autori.Add(a3);

            dvd1.Scaffale = s3;
           
            #endregion

            Utente u1 = new Utente("Nome 1", "Cognome 1", "Telefono 1", "Email 1", "Password 1");

           

            Prestito p1 = new Prestito("P00001", new DateTime(2019, 1, 20), new DateTime(2019, 2, 20), u1, l1);
            Prestito p2 = new Prestito("P00002", new DateTime(2019, 3, 20), new DateTime(2019, 4, 20), u1, l2);

           

            Console.WriteLine("\n\nSearchByCodice: ISBN1\n\n");

            List<Documento> results = b.SearchByCodice("ISBN1");

            foreach (Documento doc in results)
            {
                Console.WriteLine(doc.ToString());

                if (doc.Autori.Count > 0)
                {
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("Autori");
                    Console.WriteLine("--------------------------");
                    foreach (Autore a in doc.Autori)
                    {
                        Console.WriteLine(a.ToString());
                        Console.WriteLine("--------------------------");
                    }
                }
            }

            Console.WriteLine("\n\nSearchPrestiti: Nome 1, Cognome 1\n\n");

            List<Prestito> prestiti = b.SearchPrestiti("Nome 1", "Cognome 1");

            foreach (Prestito p in prestiti)
            {
                Console.WriteLine(p.ToString());
                Console.WriteLine("--------------------------");
            }

            */

        }
    }
}
