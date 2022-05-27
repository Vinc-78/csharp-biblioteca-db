using System;

namespace csharp_biblioteca_db // Note: actual namespace depends on the project name.
{
    public class Program
    {
        static void Main(string[] args)
        {
            Biblioteca b = new Biblioteca("Civica");

           // b.AggiungiScaffale("s001"); dati già inseriti quindi ho commentato le righe
           // b.AggiungiScaffale("s002");
           // b.AggiungiScaffale("s003");

            b.ScaffaliBiblioteca.ForEach(item => Console.WriteLine(item.Numero));  //stampa la lista degli scaffali


            //passiamo all'inserimento dei libri e agli autori
            //prova in program / elementi da passare all'interfaccia poi all'interfaccia
            // elementi commentati perchè già inseriti nel db
            // e implementata l'interfaccia

            //List<Autore> lAutoriLibro = new List<Autore>();
            //Autore AutoreMioLibro = new Autore("Gianni","Rivera","email@email.it");
            //Autore AutoreMioLibro2 = new Autore("Luca", "Rossi", "luca@email.it");
            //lAutoriLibro.Add(AutoreMioLibro);
            //lAutoriLibro.Add(AutoreMioLibro2);
            //b.AggiungiLibro(0003, "I malavoglia", "Romanzo", 235, "s003", lAutoriLibro);


            //test per libro
            //caricati in db li ho commentati
            //List<Autore> lAutori = new List<Autore>();
            //Autore AutoreMioDvd = new Autore("Dj", "Rivera", "riveradj@email.it");
            //b.AggiungiDvd(006, "Musica da Camera", "hard Rock", 360, "S003",lAutori);





            // inizio parte dell'interfaccia console

            Console.WriteLine("Lista operazione: ");
            Console.WriteLine("\t1 : inserisci libro e auotre ");
            Console.WriteLine("\t2 : Inserisci scaffale ");
            Console.WriteLine("\t3 : Stampa ListaLibri e Autori ");
            Console.WriteLine("\t4 : Cerca per autore ");
            Console.WriteLine("Cosa vuoi fare ?");

            string op;

            while ((op = Console.ReadLine()) != "")

            {
                if (op == "1") b.GestisciOperazioneBiblioteca(1);
                else if (op == "2") b.GestisciOperazioneBiblioteca(2);
                else if (op == "3") b.GestisciOperazioneBiblioteca(3);
                else if (op == "4") b.GestisciOperazioneBiblioteca(4);

                Console.WriteLine("Lista operazione: ");
                Console.WriteLine("\t1 : inserisci libro e auotre ");
                Console.WriteLine("\t2 : Inserisci scaffale ");
                Console.WriteLine("\t3 : Stampa ListaLibri e Autori ");
                Console.WriteLine("\t4 : Cerca per autore ");
                Console.WriteLine("Cosa vuoi fare ?");
            }

           

            static void PopolaDB() 
            {
                Biblioteca b = new Biblioteca("Civica");
                StreamReader reader = new StreamReader("elenco.txt");
                string linea;
                while ((linea = reader.ReadLine()) != null)
                {
                    //una linea è, ad esempio: giuseppe mazzini e altri autori:a carlo alberto di savoja
                    var vett = linea.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                    string s = vett[0];
                    var cn = s.Split(new char[] { ' ' });
                    string nome = cn[0];
                    string cognome = "";
                    try
                    {
                        cognome = s.Substring(cn[0].Length + 1);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    string titolo = vett[1];
                    List<Autore> lAutoriLibro = new List<Autore>();

                    string email = nome + "@email.it";

                    

                    Autore AutoreMioLibro = new Autore(nome, cognome, email);
                    lAutoriLibro.Add(AutoreMioLibro);

                    b.AggiungiLibro(DB.GetUnicoId(), titolo, "Libro", 1, "s001", lAutoriLibro);

                }


                reader.Close();

            }

        }
    }
}
