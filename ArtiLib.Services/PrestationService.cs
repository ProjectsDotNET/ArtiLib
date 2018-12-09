using ArtiLib.Data;
using ArtiLib.Entites;
using ArtiLib.Interfaces;
using ArtiLib.Utils;
using System.Collections.Generic;

namespace ArtiLib.Services
{
    public class PrestationService : IPrestationService
    {
        private DaoPrestation daoPrestation;

        public PrestationService()
        {
            daoPrestation = Singleton<DaoPrestation>.Instance;
        }

        public int Add(Prestation entity)
        {
            return daoPrestation.Insert(entity);
        }

        public void Edit(Prestation entity)
        {
            daoPrestation.Update(entity);
        }

        public IEnumerable<Prestation> GetAll()
        {
            return daoPrestation.GetAll();
        }

        public Prestation GetById(int id)
        {
            return daoPrestation.GetById(id);
        }

        public void RemoveById(int id)
        {
            daoPrestation.DeleteById(id);
        }
    }
}