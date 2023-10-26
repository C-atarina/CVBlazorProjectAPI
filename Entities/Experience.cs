using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CV.Entities
{
    public class ExperienceEntity
    {
        [Key]
        public int Id_Experience { get; set; }
        [Required]
        public required string Nom_Entreprise { get; set; }
        public string? Poste { get; set; }
        [Required]
        public DateTime DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
        [Required]
        public string? Description { get; set; }

        public int Id_Profil { get; set; }
        [ForeignKey("Id_Profil")]
        public ProfilEntity? Profil { get; set; }

    }

}