using ArtiLib.Data.DaoUtils;
using ArtiLib.Entites;
using Dapper;
using System.Collections.Generic;
using System.Transactions;

namespace ArtiLib.Data
{
    public class DaoAvis : DaoOperations<Avis>
    {
        public virtual IEnumerable<Avis> GetAllMapping()
        {
            using (var Transaction = new TransactionScope())
            {
                var result = Connection.Query<Avis, PrestationArtisan, Avis>
                    (typeof(Avis).GetAllMappingQuery(), (avis, prestationArtisan) =>
                    {
                        avis.PrestationArtisan = prestationArtisan;
                        return avis;
                    }, splitOn: "Id");
                Transaction.Complete();
                return result;
            }
        }
    }
}