using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using BancaTest2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization; ///x ruoli
using Microsoft.AspNetCore.Authorization;// x ruoli

// qui vanno tutte le customizzazioni 
namespace BancaTest2
{
    public class Startup
    {

        private string connectionString;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            connectionString = Configuration.GetConnectionString("DefaultConnection");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //ConfigureServices: metodo facoltativo per configurare i servizi dell'app. 
        //Un servizio è un componente riutilizzabile che fornisce la funzionalità delle app. 
        //I servizi vengono registrati in questo metodo e utilizzati nell'app tramite l' inserimento di dipendenze (DI) 
        //o di ApplicationServices.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => 
                                                    options.UseSqlServer(connectionString)); //da stringa di connessione a AppDbContext.cs


            //AddDefaultIdentity aggiunge intervista
            //    services.AddIdentity<Utente, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)

            //services.AddDefaultIdentity<Utente>(options => options.SignIn.RequireConfirmedAccount = true)
            //      .AddRoles<IdentityRole>()
            //      .AddEntityFrameworkStores<AppDbContext>();


            services.AddDefaultIdentity<Utente>(options => options.SignIn.RequireConfirmedAccount = true)
                 .AddRoles<IdentityRole>()  // aggiunto per autorizzazione
                  .AddEntityFrameworkStores<AppDbContext>()
                 .AddDefaultUI();

            services.AddControllersWithViews();
        

            services.AddRazorPages();

            services.AddControllers(config =>
            {
                // using Microsoft.AspNetCore.Mvc.Authorization;
                // using Microsoft.AspNetCore.Authorization;
                var policy = new AuthorizationPolicyBuilder()  //aggiunta per autorizzazione
                                 .RequireAuthenticatedUser()
                                 .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //metodo Configure per creare la pipeline di elaborazione delle richieste dell'app.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //UseRouting, UseAuthentication, UseAuthorization, and UseEndpoints must be called in the order shown in the preceding code.


            app.UseRouting();
            app.UseAuthentication(); //aggiunta autenticazione
            app.UseAuthorization();

        //    services.AddIdentity<Utente, Ruolo>()
        //.AddDefaultUI(UIFramework.Bootstrap4)
        //.AddEntityFrameworkStores<AppDbContext>()
        //.AddDefaultTokenProviders();




            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}",
                   defaults: new { controller = "Home", action = "Index" });
                endpoints.MapRazorPages();





            });
        }
    }
}
