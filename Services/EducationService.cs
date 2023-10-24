using CV.Entities;
using CV.Models;
using DbContexts;

namespace CVServices
{
    public class EducationService
    {
        private readonly CVDbContext _dbContext;

        public EducationService(CVDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public EducationModel AddEducation(EducationModel educationModel)
        {
            EducationEntity education = new EducationEntity
            {
                NomEcole = educationModel.NomEcole ?? throw new Exception("Nom de l'école manquant"),
                Diplome = educationModel.Diplome ?? throw new Exception("Diplome manquant"),
                DateDebut = educationModel.DateDebut,
                DateFin = educationModel.DateFin,
                Id_Profil = educationModel.Id_Profil
            };

            _dbContext.EducationEntities.Add(education);
             _dbContext.SaveChanges();

            EducationModel educationToSend = new EducationModel
            {
                Id_Education = education.Id_Education,
                NomEcole = education.NomEcole,
                DateDebut = education.DateDebut,
                DateFin = education.DateFin,
                Diplome = education.Diplome,
                Id_Profil = education.Id_Profil
            };

            return educationToSend;
        }

        public List<EducationModel> GetEducationsById(int id)
        {
            List<EducationModel> listEducation = new List<EducationModel>();

            List<EducationEntity> educations = _dbContext.EducationEntities.Where(c => c.Id_Profil == id).OrderByDescending(e => e.DateDebut).ToList();

            foreach (EducationEntity e in educations)
            {
                EducationModel education = new EducationModel
                {
                    Id_Education = e.Id_Education,
                    NomEcole = e.NomEcole,
                    DateDebut = e.DateDebut,
                    DateFin = e.DateFin,
                    Diplome = e.Diplome,
                    Id_Profil = e.Id_Profil
                };

                listEducation.Add(education);

            }

            return listEducation;
        }

        public void UpdateEducation(EducationModel education)
        {
            EducationEntity educationEntity = _dbContext.EducationEntities?.FirstOrDefault(e => e.Id_Education == education.Id_Education) ?? throw new Exception("Cette education n'existe pas");

            if (education.NomEcole != null)
            {
                educationEntity.NomEcole = education.NomEcole;
            }

            if (education?.DateDebut != null)
            {
                educationEntity.DateDebut = education.DateDebut;
            }

            if (education?.DateFin != null)
            {
                educationEntity.DateFin = education.DateFin;
            }

            if (education?.Diplome != null)
            {
                educationEntity.Diplome = education.Diplome;
            }

            _dbContext.SaveChanges();
        }

        public void DeleteEducation(int id_education)
        {
            EducationEntity educationEntity = _dbContext.EducationEntities.FirstOrDefault(p => p.Id_Education == id_education) ?? throw new Exception("Cette education n'existe pas");

            _dbContext.EducationEntities.Remove(educationEntity);

            _dbContext.SaveChanges();
        }
    }
}