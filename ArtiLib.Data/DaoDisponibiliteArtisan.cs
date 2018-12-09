using ArtiLib.Data.DaoUtils;
using ArtiLib.Entites;
using Dapper;
using System.Collections.Generic;
using System.Transactions;

namespace ArtiLib.Data
{
    public class DaoDisponibiliteArtisan : DaoOperations<DisponibiliteArtisan>
    {
        public IEnumerable<DisponibiliteArtisan> GetAllMapping()
        {
            using (var Transaction = new TransactionScope())
            {
                var result = Connection.Query<DisponibiliteArtisan, Artisan, DisponibiliteArtisan>
                    (typeof(DisponibiliteArtisan).GetAllMappingQuery(), (disponibiliteArtisan, artisan) =>
                    {
                        disponibiliteArtisan.Artisan = artisan;
                        return disponibiliteArtisan;
                    }, splitOn: "Id");
                Transaction.Complete();
                return result;
            }
        }
    }
}