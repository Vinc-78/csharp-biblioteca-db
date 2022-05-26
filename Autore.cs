using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca_db
{
    
    public class Autore : Persona
    {
        public string mail = "";
        public long codiceAutore;
        public Autore(string Nome, string Cognome, string mail) : base(Nome, Cognome)
        {
            this.mail = mail;
            this.codiceAutore = GeneraCodiceAutore();
        }

        public long GeneraCodiceAutore() 
        {
            //return 1000 + this.Nome.Length + this.Cognome.Length + this.mail.Length; //da implementare la funzione
            return DB.GetUnicoId();
        }
    }
}
