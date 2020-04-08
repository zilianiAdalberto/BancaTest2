using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancaTest2.Models
{
          public class AppSeed // classe popolamento db
        {
            public static double Price { get; private set; }
            public static string UtenteId { get; private set; }
            //public static string UtenteId { get; private set; }
        public static void Seed(AppDbContext context) //popolamento db
            {

                if (!context.Users.Any()) //Users è la tabella Utente
                {

                    //context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Utente] ON;");
                    context.AddRange(
                      
                     new Utente()
                     {
                         Email="ziliani.alberto@outlook.it",
                         Nome = "Gino",
                         Cognome="Tortorella",
                         PasswordHash= "AQAAAAEAACcQAAAAELc3ecf3U31XVJqOCJxYbrFJnibMyiR5pImvZc9GN6MJUX9+sn9xMz0iImQ0Ox5OOw==",
                         EmailConfirmed=true

                     },

                new MovimentoDare()
                {
                    UtenteId= "9e4fd936-b978-48be-afdb-06aca89960e0",
                   Cifra =-1200
                 },

                new MovimentoAvere()
                {
                    UtenteId = "9e4fd936-b978-48be-afdb-06aca89960e0",
                    Cifra = 1500
                }


                );


                context.SaveChanges();
                  //  context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Utente] OFF;");

                };
            }
        }
    }

