using ArtiLib.Data;
using ArtiLib.Entites;
using ArtiLib.Interfaces;
using ArtiLib.Utils;
using System.Collections.Generic;

namespace ArtiLib.Services
{
    public class PrestationArtisanService : IPrestationArtisanService
    {
        private DaoPrestationArtisan daoPrestationArtisan;

        public PrestationArtisanService()
        {
            daoPrestationArtisan = Singleton<DaoPrestationArtisan>.Instance;
        }

        public int Add(PrestationArtisan entity)
        {
            return daoPrestationArtisan.Insert(entity);
        }

        public void Edit(PrestationArtisan entity)
        {
            daoPrestationArtisan.Update(entity);
        }

        public IEnumerable<PrestationArtisan> GetAll()
        {
            return daoPrestationArtisan.GetAllMapping();
        }

        public IEnumerable<PrestationArtisan> GetAllMapping()
        {
            return daoPrestationArtisan.GetAllMapping();
        }

        public PrestationArtisan GetById(int id)
        {
            return daoPrestationArtisan.GetById(id);
        }

        public void RemoveById(int id)
        {
            daoPrestationArtisan.DeleteById(id);
        }
    }
}