using ArtiLib.Data;
using ArtiLib.Entites;
using ArtiLib.Interfaces;
using ArtiLib.Utils;
using System.Collections.Generic;

namespace ArtiLib.Services
{
    public class DisponibiliteArtisanService : IDisponibiliteArtisanService
    {
        private DaoDisponibiliteArtisan daoDisponibiliteArtisan;

        public DisponibiliteArtisanService()
        {
            daoDisponibiliteArtisan = Singleton<DaoDisponibiliteArtisan>.Instance;
        }

        public int Add(DisponibiliteArtisan entity)
        {
            return daoDisponibiliteArtisan.Insert(entity);
        }

        public void Edit(DisponibiliteArtisan entity)
        {
            daoDisponibiliteArtisan.Update(entity);
        }

        public IEnumerable<DisponibiliteArtisan> GetAll()
        {
            return daoDisponibiliteArtisan.GetAll();
        }

        public IEnumerable<DisponibiliteArtisan> GetAllMapping()
        {
            return daoDisponibiliteArtisan.GetAllMapping();
        }

        public DisponibiliteArtisan GetById(int id)
        {
            return daoDisponibiliteArtisan.GetById(id);
        }

        public void RemoveById(int id)
        {
            daoDisponibiliteArtisan.DeleteById(id);
        }
    }
}