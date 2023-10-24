using System.Linq.Expressions;
using System.Threading.Tasks;
using CV.Entities;
using CV.Models;
using DbContexts;

namespace CVServices 
{
    public class ProfilService
    {
        private readonly CVDbContext _dbContext;

        public ProfilService(CVDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ProfilModel AddProfile(ProfilModel profilModel)
        {
            if (profilModel is not null)
            {
                ProfilEntity profil = new ProfilEntity
                {
                    Nom = profilModel.Nom ?? throw new Exception("Nom requis"),
                    Prenom = profilModel.Prenom ?? throw new Exception("Prénom requis"),
                    Tel = profilModel.Tel,
                    Email = profilModel.Email,
                    Description = profilModel.Description,
                    Photo = profilModel.Photo
                };

                _dbContext.ProfilEntities.Add(profil);
                _dbContext.SaveChanges();

                ProfilModel profilToSend = new ProfilModel
                {
                    Id_Profil = profil.Id_Profil,
                    Nom = profil.Nom,
                    Prenom = profil.Prenom,
                    Tel = profil.Tel,
                    Email = profil.Email,
                    Description = profil.Description
                };

                return profilToSend;
            }
            else{
                throw new Exception();
            }
        }

        public ProfilModel GetProfilById(int id)
        {
            ProfilEntity profil = _dbContext.ProfilEntities.FirstOrDefault(p => p.Id_Profil == id) ?? throw new Exception("Ce profil n'existe pas");

            ProfilModel profilModel = new ProfilModel {
                Id_Profil = profil.Id_Profil,
                Nom = profil.Nom,
                Prenom = profil.Prenom,
                Tel = profil.Tel,
                Email = profil.Email,
                Description = profil.Description
            };

            return profilModel;
        }

        public List<ProfilModel> GetAllProfiles()
        {
            List<ProfilModel> listProfiles = new List<ProfilModel>();

            List<ProfilEntity> profils = _dbContext.ProfilEntities.ToList();

            foreach (ProfilEntity p in profils)
            {
                ProfilModel profil = new ProfilModel{
                    Id_Profil = p.Id_Profil,
                    Nom = p.Nom,
                    Prenom = p.Prenom,
                    Tel = p.Tel,
                    Email = p.Email,
                    Description = p.Description
                };

                listProfiles.Add(profil);
                
            }

            return listProfiles;
        }

        public void UpdateProfile(ProfilModel profile)
        {
            ProfilEntity profilEntity = _dbContext.ProfilEntities.FirstOrDefault(p => p.Id_Profil == profile.Id_Profil) ?? throw new Exception("Ce profil n'existe pas");

            if (profile.Nom != null)
            {
                profilEntity.Nom = profile.Nom;
            }

            if (profile.Prenom != null)
            {
                profilEntity.Prenom = profile.Prenom;
            }

            if (profile.Tel != null)
            {
                profilEntity.Tel = profile.Tel;
            }

            if (profile.Email != null)
            {
                profilEntity.Email = profile.Email;
            }

            if (profile.Description != null)
            {
                profilEntity.Description = profile.Description;
            }

            _dbContext.SaveChanges();
        }

        public void DeleteProfile(int id_user)
        {
            ProfilEntity profilEntity = _dbContext.ProfilEntities.FirstOrDefault(p => p.Id_Profil == id_user) ?? throw new Exception("Ce profil n'existe pas");

            _dbContext.ProfilEntities.Remove(profilEntity);

            _dbContext.SaveChanges();
        }
    }
}