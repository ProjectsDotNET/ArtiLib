using ArtiLib.Data;
using ArtiLib.Entites;
using ArtiLib.Interfaces;
using ArtiLib.Utils;
using System.Collections.Generic;

namespace ArtiLib.Services
{
    public class AvisService : IAvisService
    {
        private DaoAvis daoAvis;

        public AvisService()
        {
            daoAvis = Singleton<DaoAvis>.Instance;
        }

        public int Add(Avis entity)
        {
            return daoAvis.Insert(entity);
        }

        public void Edit(Avis entity)
        {
            daoAvis.Update(entity);
        }

        public IEnumerable<Avis> GetAll()
        {
            return daoAvis.GetAll();
        }

        public IEnumerable<Avis> GetAllMapping()
        {
            return daoAvis.GetAllMapping();
        }

        public Avis GetById(int id)
        {
            return daoAvis.GetById(id);
        }

        public void RemoveById(int id)
        {
            daoAvis.DeleteById(id);
        }
    }
}