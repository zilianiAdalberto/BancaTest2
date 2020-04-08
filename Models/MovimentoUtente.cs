using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BancaTest2.Models
{
    
    
    public class MovimentoUtente
    {
        public int MovimentoUtenteId { get; set; }
        public string UtenteId { get; set; }
        public DateTime MovimentoData { get; set; }
        public double Cifra { get; set; }

    }
}
