using ArtiLib.Data;
using ArtiLib.Entites;
using ArtiLib.Interfaces;
using ArtiLib.Utils;
using System.Collections.Generic;

namespace ArtiLib.Services
{
    public class RendezVousService : IRendezVousService
    {
        private DaoRendezVous daoRendezVous;

        public RendezVousService()
        {
            daoRendezVous = Singleton<DaoRendezVous>.Instance;
        }

        public int Add(RendezVous entity)
        {
            return daoRendezVous.Insert(entity);
        }

        public void Edit(RendezVous entity)
        {
            daoRendezVous.Update(entity);
        }

        public IEnumerable<RendezVous> GetAll()
        {
            return daoRendezVous.GetAll();
        }

        public IEnumerable<RendezVous> GetAllMapping()
        {
            return daoRendezVous.GetAllMapping();
        }

        public RendezVous GetById(int id)
        {
            return daoRendezVous.GetById(id);
        }

        public void RemoveById(int id)
        {
            daoRendezVous.DeleteById(id);
        }
    }
}