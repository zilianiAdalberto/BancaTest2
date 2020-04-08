using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BancaTest2.Models
{
    public class Utente : IdentityUser
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }

    }
}