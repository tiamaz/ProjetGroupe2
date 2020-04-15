using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ProjetGroupe2.Data;
using ProjetGroupe2.Model;

namespace ProjetGroupe2.Pages
{

    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly ApplicationDbContext _db;

        public IEnumerable<Publication> publication {get; set;}

        private readonly UserManager<IdentityUser> _userManager;



        public IndexModel(ILogger<IndexModel> logger, 
        ApplicationDbContext db,
        UserManager<IdentityUser> userManager
        )
        {
            _logger = logger;
            _db = db;
            _userManager = userManager;
        }

        public async Task OnGet()
        {

            var user = await _userManager.GetUserAsync(HttpContext.User);
       /*     classes = (from clas in _db.classe
                            where clas.IdProf == userId
                            select clas
                            ).ToList();
           publication =  ( from clas in classes
                            join pub in _db.publication
                            on clas.IdClasse equals pub.IdClasse
                            select pub).ToList(); */


           publication =  ( from clas in _db.classe 
                            where clas.IdProf == user.Id
                            join pub in _db.publication
                            on clas.IdClasse equals pub.IdClasse
                            select pub).ToList();


        }
    }
}
