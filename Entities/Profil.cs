using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CV.Entities {
    public class ProfilEntity
    {
        [Key]
        public int Id_Profil { get; set; }
        [Required]
        public required string Nom { get; set; }
        [Required]
        public required string Prenom { get; set; }
        [Required]
        public string? Tel { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Description { get; set; }
        public string? Photo { get; set; }

        public List<ExperienceEntity>? Experience { get; set; }
        public List<CompetenceEntity>? Competence { get; set; }
        public List<EducationEntity>? Education { get; set; }


    }

}