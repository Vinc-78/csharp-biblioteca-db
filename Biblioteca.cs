﻿using System;
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

        public void AggiungiLibro(long codice, string titolo, string settore, int pagine, string scaffale, List<Autore>listaAutori)
        {
            Libro MioLibro = new(codice,titolo, settore, pagine, scaffale);
            MioLibro.Stato = Stato.Disponibile;
            DB.libroAdd(MioLibro, listaAutori);
        
        }
        public void AggiungiDvd(long codice, string titolo, string settore, int durata, string scaffale, List<Autore> listaAutori)
        {
            DVD MioDvd = new(codice,titolo,settore, durata, scaffale);
            
            MioDvd.Stato = Stato.Disponibile;

            DB.DVDAdd(MioDvd, listaAutori);

        }

        public void GestisciOperazioneBiblioteca(int iCodiceOperazione)
        {
            List<Documento> lResult;
            string sAppo;
            switch (iCodiceOperazione)
            {
                case 1: //Da implementare i controlli nell'inserimento e conversione in int
                        //e aggiornare repo su Vinc-78

                    Console.WriteLine("inserisci i dati o l'inserimento non funziona");
                    Biblioteca b = new Biblioteca("Civica");
                    int numeroAutori = 0;
                    string snumeroAutori;
                    List<Autore> lAutoriLibro = new List<Autore>();

                    Console.WriteLine("Quanti autori ha il libro ?");
                    snumeroAutori = Console.ReadLine();
                    numeroAutori = Int32.Parse(snumeroAutori);

                    for (int i = 0; i < numeroAutori; i++)

                    {
                        Console.WriteLine("inserisci nome autore :");
                        string nomeAutore = Console.ReadLine();
                        Console.WriteLine("inserisci cognome autore :");
                        string cognomeAutore = Console.ReadLine();
                        Console.WriteLine("inserisci email autore :");
                        string emailAutore = Console.ReadLine();

                        Autore AutoreMioLibro = new Autore(nomeAutore, cognomeAutore, emailAutore);
                        lAutoriLibro.Add(AutoreMioLibro);
                    }

                    Console.WriteLine("Autori inseriti");




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

                case 3:

                    DB.StampaLibriAutori(DB.libriConAutoriGet());

                    break;

                case 4:

                    string nome;
                    string cognome;
                    Console.WriteLine("Inserisci nome dell'autore :");
                    nome =Console.ReadLine();

                    Console.WriteLine("Inserisci cognome dell'autore : ");
                    cognome = Console.ReadLine();

                    Console.WriteLine("I documenti relativi al tuo autore sono: ");

                    var lista = new List<List<string>>();

                    lista = DB.RicercaPerAutore(nome, cognome);

                    DB.StampaLibriAutori(lista);

                    Console.WriteLine("---------------------");


                    break;

            }
            
        }


    }
}
