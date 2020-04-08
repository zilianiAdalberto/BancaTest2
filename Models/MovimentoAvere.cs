using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancaTest2.Models
{
    public class MovimentoAvere
    {
        public MovimentoAvere()
        {

        }
        public MovimentoAvere(string id, double importo)
            {
                UtenteId = id;
                MovimentoData = DateTime.Today;
                Cifra = importo;
            }
        
        public int MovimentoAvereId{ get; set; }

        public string UtenteId { get; set; }

        public DateTime MovimentoData{ get; set; }

        public double Cifra { get; set; }
        
    }
}
