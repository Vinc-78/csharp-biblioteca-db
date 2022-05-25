using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca_db
{
    public class Scaffale
    {
        public string Numero { get; set; }

        public Scaffale(string Numero)
        {
            this.Numero = Numero;
        }
    }
}
