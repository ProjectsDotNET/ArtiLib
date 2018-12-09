using ArtiLib.Data;
using ArtiLib.Entites;
using ArtiLib.Interfaces;
using ArtiLib.Utils;
using System.Collections.Generic;

namespace ArtiLib.Services
{
    public class StatutRendezVousService : IStatutRendezVousService
    {
        private DaoStatutRendezVous daoStatutRendezVous;

        public StatutRendezVousService()
        {
            daoStatutRendezVous = Singleton<DaoStatutRendezVous>.Instance;
        }

        public int Add(StatutRendezVous entity)
        {
            return daoStatutRendezVous.Insert(entity);
        }

        public void Edit(StatutRendezVous entity)
        {
            daoStatutRendezVous.Update(entity);
        }

        public IEnumerable<StatutRendezVous> GetAll()
        {
            return daoStatutRendezVous.GetAll();
        }

        public StatutRendezVous GetById(int id)
        {
            return daoStatutRendezVous.GetById(id);
        }

        public void RemoveById(int id)
        {
            daoStatutRendezVous.DeleteById(id);
        }
    }
}