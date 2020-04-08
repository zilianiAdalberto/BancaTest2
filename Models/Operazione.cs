using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BancaTest2.Models
{
    public class Operazione
    {
        //  public int OperazioneId { get; set; }
       

        public double Cifra{ get; set; }


        [BindProperty, Required]
        public int TipoOperazione{ get; set; } 

    }
}
