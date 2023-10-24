using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CV.Models
{
    public class ProfilModel

    {
        public int? Id_Profil { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public string? Tel { get; set; }
        public string? Email { get; set; }
        public string? Description { get; set; }
        public string? Photo { get; set; }
    }

}