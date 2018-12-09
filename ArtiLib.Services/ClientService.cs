using ArtiLib.Data;
using ArtiLib.Entites;
using ArtiLib.Interfaces;
using ArtiLib.Utils;
using System.Collections.Generic;

namespace ArtiLib.Services
{
    public class ClientService : IClientService
    {
        private DaoClient daoClient;

        public ClientService()
        {
            daoClient = Singleton<DaoClient>.Instance;
        }

        public int Add(Client entity)
        {
            return daoClient.Insert(entity);
        }

        public void RemoveById(int id)
        {
            daoClient.DeleteById(id);
        }

        public IEnumerable<Client> GetAll()
        {
            return daoClient.GetAll();
        }

        public Client GetById(int id)
        {
            return daoClient.GetById(id);
        }

        public void Edit(Client entity)
        {
            daoClient.Update(entity);
        }
    }
}