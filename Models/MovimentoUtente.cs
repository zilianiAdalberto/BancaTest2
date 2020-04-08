using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancaTest2.Models
{
    public class MovimentoUtente
    {
        public int MovimentoUtenteId { get; set; }  
        public DateTime MovimentoData { get; set; }
        public double Cifra { get; set; }

    }
}
