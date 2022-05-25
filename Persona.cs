using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca_db
{
    public class Persona
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }

        public Persona(string Nome, string Cognome)
        {
            this.Nome = Nome;
            this.Cognome = Cognome;
        }

        public override string ToString()
        {
            return string.Format("Nome:{0}\nCognome:{1}",
                this.Nome,
                this.Cognome);
        }
    }
}
