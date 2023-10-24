namespace CV.Models
{
    public class CompetenceModel
    {
        public int? Id_Competences { get; set; }
        public string? Nom { get; set; }
        public string? Logo { get; set; }
        public int? Id_TypeCompetences { get; set; }
        public int? Id_Profil { get; set; }
    }
}