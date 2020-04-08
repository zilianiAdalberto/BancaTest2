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
                         Email="ziliani.alberto@gmail.com",
                         Nome = "Gino",
                         Cognome="Tortorella",
                         PasswordHash= "AQAAAAEAACcQAAAAELc3ecf3U31XVJqOCJxYbrFJnibMyiR5pImvZc9GN6MJUX9+sn9xMz0iImQ0Ox5OOw==",
                         EmailConfirmed=true

                     });

                    context.SaveChanges();
                  //  context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Utente] OFF;");

                };
            }
        }
    }

