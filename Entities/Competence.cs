using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CV.Entities
{
    public class CompetenceEntity
    {
        [Key]
        public int Id_Competences { get; set; }
        [Required]
        public required string Nom { get; set; }
        public string? Logo { get; set; }
        public int Id_TypeCompetences { get; set; }
        [ForeignKey("Id_TypeCompetences")]
        public TypeCompetenceEntity? TypeCompetences { get; set; }

        public int Id_Profil { get; set; }
        [ForeignKey("Id_Profil")]
        public ProfilEntity? Profil { get; set; }

    }

}