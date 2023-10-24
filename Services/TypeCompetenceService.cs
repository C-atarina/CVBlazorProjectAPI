using CV.Entities; // Assurez-vous d'importer le bon espace de noms pour vos entités
using Microsoft.EntityFrameworkCore;
using DbContexts;
using System.Collections.Generic;
using System.Threading.Tasks;
using CV.Models;


namespace CVServices
{
    public class TypeCompetenceService
    {
        private readonly CVDbContext _dbContext;

        public TypeCompetenceService(CVDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<TypeCompetenceModel> GetAllTypeCompetences()
        {
            List<TypeCompetenceEntity> typeCompetenceEntities = _dbContext.TypeCompetenceEntities.ToList();
            
            List<TypeCompetenceModel> typeCompetence = new List<TypeCompetenceModel>();

            foreach (TypeCompetenceEntity entity in typeCompetenceEntities)
            {
                TypeCompetenceModel typeCompetenceModel = new TypeCompetenceModel {
                    Id_TypeCompetences = entity.Id_TypeCompetences,
                    TypeCompetences = entity.Type
                };

                typeCompetence.Add(typeCompetenceModel);   
            }
            return typeCompetence;
        }
    }

}
