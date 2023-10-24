using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CV.Entities
{
    public class EducationEntity
    {
        [Key]
        public int Id_Education { get; set; }
        [Required]
        public required string NomEcole { get; set; }
        [Required]
        public required string Diplome { get; set; }
        [Required]
        public DateTime DateDebut { get; set; }
        public DateTime? DateFin { get; set; }

        public int Id_Profil { get; set; }
        [ForeignKey("Id_Profil")]
        public ProfilEntity? Profil { get; set; }

    }

}