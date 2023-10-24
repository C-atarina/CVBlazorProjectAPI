namespace CV.Models
{
    public class EducationModel
    {
        public int Id_Education { get; set; }
        public string? NomEcole { get; set; }
        public string? Diplome { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
        public int Id_Profil { get; set; }
    }
}