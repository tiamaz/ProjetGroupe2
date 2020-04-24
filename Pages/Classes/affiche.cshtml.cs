using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetGroupe2.Data;
using ProjetGroupe2.Model;

namespace ProjetGroupe2.Pages.Classes
{
    public class afficheModel : PageModel
    {

        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;

        public IEnumerable<Publication> publications {get; set;}

        [BindProperty]
        public Publication publication {get; set;}


        public afficheModel(
        ApplicationDbContext db,
        UserManager<IdentityUser> userManager
        )
        {
           
            _db = db;
            _userManager = userManager;
        }
        public void OnGet(int idClasse)
        {

            publications = _db.publication.Where(m => m.IdClasse == idClasse).ToList();   

            publication = new Publication();
            publication.IdClasse = idClasse;
        }

        public IActionResult OnPost()
        {

            if(ModelState.IsValid)
            {

                publication.DatePublication = DateTime.Now.ToString();
                 _db.publication.Add(publication);
                _db.SaveChanges();
                return RedirectToPage("index");
            }

            return Page();
             
        }
    }
}
