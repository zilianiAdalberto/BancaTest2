using Microsoft.AspNetCore.Identity; // aggiunti per creare identità scaffolded
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;// idem sopra
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;




namespace BancaTest2.Models
{
    //  public class AppDbContext : DbContext senza autenticazione

    //public class AppDbContext : IdentityDbContext<Utente> se no lo scaffolded item 
    //dell' autenticazione non vede il context


    //  public class AppDbContext : IdentityDbContext<Utente>
    public class AppDbContext : IdentityDbContext<Utente>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Cliente> Clienti { get; set; }

        public DbSet<MovimentoDare> MovimentiDare { get; set; }

        public DbSet<MovimentoAvere> MovimentiAvere { get; set; }

        public DbSet<MovimentoUtente> MovimentiUtente{ get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            /* modelBuilder.Entity<MovimentoDare>()
                 .HasKey(c => new { c.MovimentoDareId, c.ClienteId });
             modelBuilder.Entity<MovimentoAvere>()
             .HasKey(c => new { c.MovimentoAvereId, c.ClienteId });*/

            modelBuilder.Entity<MovimentoUtente>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("MovimentiUtente");

            });







        }


    }
}

