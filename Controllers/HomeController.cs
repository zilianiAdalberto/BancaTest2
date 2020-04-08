using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BancaTest2.Models;
using Microsoft.AspNetCore.Identity;

namespace BancaTest2.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _appdbcontext;
        private RoleManager<IdentityRole> _roleManager;
        private ILogger<HomeController> _logger;
        private UserManager<Utente> _userManager;

        public HomeController(RoleManager<IdentityRole> roleManager, ILogger<HomeController> logger, UserManager<Utente> userManager, AppDbContext appdbcontext)
        {
            _logger = logger;
           _roleManager = roleManager;
            _appdbcontext = appdbcontext;
            _userManager = userManager;


        }



       public async Task<IActionResult> Index()
        {
            ViewBag.Roles = _roleManager.Roles;
            var u = await _userManager.GetUserAsync(HttpContext.User); //utente collegato
            var movimenti = _appdbcontext.MovimentiUtente.Where(mu => mu.MovimentoUtenteId.Equals(u.Id)); //id utente  collegato

            return View();
        }


        public async Task<IActionResult> CreateOperazione()
        {
            return View();
        }



        //public async Task<IActionResult> CreateFormOperazione()
        //{
        //    List<ClienteBase> clienti = await EstrazioneClienti();
        //    var bigliettoViewModel = new BigliettiViewModel()
        //    {
        //        Clienti = clienti

        //    };
        //    return View(bigliettoViewModel);
        //}

        [HttpPost]
        public async Task<ActionResult> CreateOperazione(Operazione fm)
        {
            var u = await _userManager.GetUserAsync(HttpContext.User);
            object operazione ; 

            if (ModelState.IsValid)
            {
                if (fm.TipoOperazione == 0)
                   operazione = new MovimentoAvere( u.Id, fm.Cifra);
                else operazione = new MovimentoDare(u.Id, fm.Cifra);

                _appdbcontext.Add(operazione);
                await _appdbcontext.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(fm);
            }

        }




        public async Task<ActionResult<IEnumerable<MovimentoUtente>>> ListMovimentiUtente()
        {

            var movimenti = await _appdbcontext.MovimentiUtente.ToListAsync();

            return View(movimenti);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
