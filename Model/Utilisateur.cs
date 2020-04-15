

using Microsoft.AspNetCore.Identity;

namespace ProjetGroupe2.Model
{
    public class Utilisateur : IdentityUser
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public char Status { get; set; }
    }
}