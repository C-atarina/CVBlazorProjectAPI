using CV.Entities;
using CV.Models;
using DbContexts;

namespace CVServices
{
    public class ExperienceService
    {
        private readonly CVDbContext _dbContext;

        public ExperienceService(CVDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ExperienceModel AddExperience(ExperienceModel experienceModel)
        {
            ExperienceEntity experience = new ExperienceEntity
            {
                Nom_Entreprise = experienceModel.Nom_Entreprise,
                Poste = experienceModel.Poste,
                DateDebut = experienceModel.DateDebut,
                DateFin = experienceModel.DateFin,
                Description = experienceModel.Description,
                Id_Profil = experienceModel.Id_Profil
            };

            _dbContext.ExperienceEntities?.Add(experience);
            _dbContext.SaveChanges();
            ExperienceModel experienceToSend = new ExperienceModel
            {
                Id_Experience = experience.Id_Experience,
                Nom_Entreprise = experience.Nom_Entreprise,
                Poste = experience.Poste,
                DateDebut = experience.DateDebut,
                DateFin = experience.DateFin,
                Description = experience.Description,
                Id_Profil = experience.Id_Profil
            };
            return experienceToSend;
        }

        public List<ExperienceModel> GetExperiencesById(int id)
        {
            List<ExperienceModel> listExperience = new List<ExperienceModel>();

            List<ExperienceEntity> experiences = _dbContext.ExperienceEntities?.Where(c => c.Id_Profil == id).OrderByDescending(c => c.DateDebut).ToList() ?? throw new Exception();

            foreach (ExperienceEntity e in experiences)
            {
                ExperienceModel experience = new ExperienceModel
                {
                    Id_Experience = e.Id_Experience,
                    Nom_Entreprise = e.Nom_Entreprise,
                    Poste = e.Poste,
                    DateDebut = e.DateDebut,
                    DateFin = e.DateFin,
                    Description = e.Description,
                    Id_Profil = e.Id_Profil
                };

                listExperience.Add(experience);

            }

            return listExperience;
        }

        public void UpdateExperience(ExperienceModel experience)
        {
            ExperienceEntity experienceEntity = _dbContext.ExperienceEntities?.FirstOrDefault(e => e.Id_Experience == experience.Id_Experience) ?? throw new Exception("Cette expérience n'existe pas");

            if (experience.Nom_Entreprise != null)
            {
                experienceEntity.Nom_Entreprise = experience.Nom_Entreprise;
            }

            if (experience.Poste != null)
            {
                experienceEntity.Poste = experience.Poste;
            }

            if (experience?.DateDebut != null)
            {
                experienceEntity.DateDebut = experience.DateDebut;
            }

            if (experience?.DateFin != null)
            {
                experienceEntity.DateFin = experience.DateFin;
            }

            if (experience?.Description != null)
            {
                experienceEntity.Description = experience.Description;
            }

            _dbContext.SaveChanges();
        }

        public void DeleteExperience(int id_experience)
        {
            ExperienceEntity experienceEntity = _dbContext.ExperienceEntities.FirstOrDefault(p => p.Id_Experience == id_experience) ?? throw new Exception("Cette expérience n'existe pas");

            _dbContext.ExperienceEntities.Remove(experienceEntity);

            _dbContext.SaveChanges();
        }
    }
}