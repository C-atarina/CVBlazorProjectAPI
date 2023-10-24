using Microsoft.EntityFrameworkCore;
using CV.Entities;
using CV.Constants;

namespace DbContexts
{
    public class CVDbContext : DbContext
    {
        public DbSet<ProfilEntity> ProfilEntities { get; set; }
        public DbSet<ExperienceEntity> ExperienceEntities { get; set; }
        public DbSet<EducationEntity> EducationEntities { get; set; }
        public DbSet<TypeCompetenceEntity> TypeCompetenceEntities { get; set; }
        public DbSet<CompetenceEntity> CompetenceEntities { get; set; }

        public CVDbContext(
            DbContextOptions<CVDbContext> options
        )
            : base(options)
        {
            ProfilEntities = Set<ProfilEntity>();
            ExperienceEntities = Set<ExperienceEntity>();
            EducationEntities = Set<EducationEntity>();
            TypeCompetenceEntities = Set<TypeCompetenceEntity>();
            CompetenceEntities = Set<CompetenceEntity>();
        }

        protected override void OnModelCreating(
            ModelBuilder builder
        )
        {
            
        }
    }
}