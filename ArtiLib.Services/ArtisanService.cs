using ArtiLib.Data;
using ArtiLib.Entites;
using ArtiLib.Interfaces;
using ArtiLib.Utils;
using System.Collections.Generic;

namespace ArtiLib.Services
{
    public class ArtisanService : IArtisanService
    {
        private DaoArtisan daoArtisan;

        public ArtisanService()
        {
            daoArtisan = Singleton<DaoArtisan>.Instance;
        }

        public int Add(Artisan entity)
        {
            return daoArtisan.Insert(entity);
        }

        public void RemoveById(int id)
        {
            daoArtisan.DeleteById(id);
        }

        public IEnumerable<Artisan> GetAll()
        {
            return daoArtisan.GetAll();
        }

        public Artisan GetById(int id)
        {
            return daoArtisan.GetById(id);
        }

        public void Edit(Artisan entity)
        {
            daoArtisan.Update(entity);
        }
    }
}