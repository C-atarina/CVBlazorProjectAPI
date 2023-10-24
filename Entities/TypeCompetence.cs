using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CV.Entities
{
    public class TypeCompetenceEntity
    {
        [Key]
        public int Id_TypeCompetences { get; set; }
        [Required]
        public required string Type { get; set; }
        public List<CompetenceEntity>? Competence { get; set; }

    }

}