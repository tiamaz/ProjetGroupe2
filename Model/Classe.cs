using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetGroupe2.Model
{
    public class Classe
    {
        [Key]
        public int IdClasse { get; set; }

        [Required]
        public string NonClasse { get; set; }
    
        [Required]
        public string Filiere { get; set; }

        [Required]
        public string Niveau { get; set; }

        [Required]
        public int NombreEtudiant { get; set; }

        [Required]
        public string IdProf { get; set; }


        [ForeignKey("IdProf")]
        public Utilisateur utilisateur { get; set; }

    }
}

