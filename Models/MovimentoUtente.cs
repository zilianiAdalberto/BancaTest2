using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BancaTest2.Models
{
    [Table]
    
    public class MovimentoUtente
    {
        public int MovimentoUtenteId { get; set; }


        public string UtenteId { get; set; }
        public int ClienteId { get; set; }
        public DateTime MovimentoData { get; set; }
        public double Cifra { get; set; }

    }
}
