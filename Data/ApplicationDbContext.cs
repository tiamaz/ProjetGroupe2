using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjetGroupe2.Model;

namespace ProjetGroupe2.Data
{
    public class ApplicationDbContext : IdentityDbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        

       public DbSet<Utilisateur> utilisateur { get; set; }

        public DbSet<Classe> classe { get; set; }

        public DbSet<Publication> publication { get; set; }

        public DbSet<EtudiantClasse> etudiantClasse { get; set; }
    }
}
