using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancaTest2.Models
{
    public class MovimentoDare
    {
        public int MovimentoDareId { get; set; }

        public MovimentoDare()
        {

        }
        public MovimentoDare(string id, double importo)
        {
            UtenteId = id;
            MovimentoData = DateTime.Today;
            Cifra = -importo;
        }
        public string UtenteId { get; set; }

        public DateTime MovimentoData { get; set; }
        public double Cifra{ get; set; }
        
    }
}
