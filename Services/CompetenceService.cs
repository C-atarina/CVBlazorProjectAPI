using CV.Entities;
using CV.Models;
using DbContexts;

namespace CVServices
{
    public class CompetenceService
    {
        private readonly CVDbContext _dbContext;

        public CompetenceService(CVDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public CompetenceModel AddCompetence(CompetenceModel competenceModel)
        {
            CompetenceEntity competence = new CompetenceEntity
            {
                Nom = competenceModel.Nom ?? throw new Exception("Nom de compétence manquant"),
                Logo = competenceModel.Logo,
                Id_TypeCompetences = competenceModel.Id_TypeCompetences ?? throw new Exception("Type de compétence manquant"),
                Id_Profil = competenceModel.Id_Profil ?? throw new Exception("Id_Profil manquant")
            };

            _dbContext.CompetenceEntities.Add(competence);
            _dbContext.SaveChanges();
            
            CompetenceModel competenceToSens = new CompetenceModel
            {
                Id_Competences = competence.Id_Competences,
                Nom = competence.Nom,
                Logo = competence.Logo,
                Id_TypeCompetences = competence.Id_Competences,
                Id_Profil = competence.Id_Profil
            };

            return competenceToSens;
        }

        public List<CompetenceModel> GetCompetencesById(int id)
        {
            List<CompetenceModel> listCompetences = new List<CompetenceModel>();

            List<CompetenceEntity> competences = _dbContext.CompetenceEntities.Where(c => c.Id_Profil == id).ToList();

            foreach (CompetenceEntity c in competences)
            {
                CompetenceModel competence = new CompetenceModel
                {
                    Id_Competences = c.Id_Competences,
                    Nom = c.Nom,
                    Logo = c.Logo,
                    Id_TypeCompetences = c.Id_Competences,
                    Id_Profil = c.Id_Profil
                };

                listCompetences.Add(competence);

            }

            return listCompetences;
        }

        public void UpdateCompetence(CompetenceModel competence)
        {
            CompetenceEntity competenceEntity = _dbContext.CompetenceEntities.FirstOrDefault(c => c.Id_Competences == competence.Id_Competences) ?? throw new Exception("Cette compétence n'existe pas");

            if (competence.Nom != null)
            {
                competenceEntity.Nom = competence.Nom;
            }

            if (competence.Logo != null)
            {
                competenceEntity.Logo = competence.Logo;
            }

            _dbContext.SaveChanges();
        }

        public void DeleteCompetence(int id_competetence)
        {
            CompetenceEntity competenceEntity = _dbContext.CompetenceEntities.FirstOrDefault(c => c.Id_Competences == id_competetence) ?? throw new Exception("Cette compétence n'existe pas");

            _dbContext.CompetenceEntities.Remove(competenceEntity);

            _dbContext.SaveChanges();
        }
    }
}