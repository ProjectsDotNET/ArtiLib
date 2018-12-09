using ArtiLib.Data.DaoUtils;
using ArtiLib.Entites;
using Dapper;
using System.Collections.Generic;
using System.Transactions;

namespace ArtiLib.Data
{
    public class DaoPrestationArtisan : DaoOperations<PrestationArtisan>
    {
        public virtual IEnumerable<PrestationArtisan> GetAllMapping()
        {
            using (var Transaction = new TransactionScope())
            {
                var result = Connection.Query<PrestationArtisan, Prestation, Artisan, PrestationArtisan>
                    (typeof(PrestationArtisan).GetAllMappingQuery(), (prestationArtisan, prestation, artisan) =>
                    {
                        prestationArtisan.Prestation = prestation;
                        prestationArtisan.Artisan = artisan;
                        return prestationArtisan;
                    }, splitOn: "Id");
                Transaction.Complete();
                return result;
            }
        }
    }
}