using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetGroupe2.Data;
using ProjetGroupe2.Model;

namespace ProjetGroupe2.Pages.Classes
{

    [Authorize]
    public class indexModel : PageModel
    {

        private readonly ApplicationDbContext _db;

        public IEnumerable<Classe> classes {get; set;}

        private readonly UserManager<IdentityUser> _userManager;



        public indexModel(
        ApplicationDbContext db,
        UserManager<IdentityUser> userManager
        )
        {
            _db = db;
            _userManager = userManager;
        }
        public async Task OnGet()
        {
                    var user = await _userManager.GetUserAsync(HttpContext.User);
                    classes = await _db.classe.Where(x => x.IdProf == user.Id).ToListAsync();
        }
    }
}
