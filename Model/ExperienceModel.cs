namespace CV.Models
{
    public class ExperienceModel
    {
        public int? Id_Experience { get; set; }
        public required string Nom_Entreprise { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
        public string? Description { get; set; }
        public int Id_Profil { get; set; }
    }
}