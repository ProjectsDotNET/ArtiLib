using ArtiLib.Data.DaoUtils;
using ArtiLib.Entites;
using Dapper;
using System.Collections.Generic;
using System.Transactions;

namespace ArtiLib.Data
{
    public class DaoRendezVous : DaoOperations<RendezVous>
    {
        public virtual IEnumerable<RendezVous> GetAllMapping()
        {
            using (var Transaction = new TransactionScope())
            {
                var result = Connection.Query<RendezVous, Client, DisponibiliteArtisan, StatutRendezVous, RendezVous, RendezVous>
                    (typeof(RendezVous).GetAllMappingQuery(), (rendezVous, client, disponibiliteArtisan, statutRendezVous, rendezVousdeplace) =>
                    {
                        rendezVous.Client = client;
                        rendezVous.DisponibiliteArtisan = disponibiliteArtisan;
                        rendezVous.StatutRendezVous = statutRendezVous;
                        rendezVous.RendezVousDeplace = rendezVousdeplace;
                        return rendezVous;
                    }, splitOn: "Id");
                Transaction.Complete();
                return result;
            }
        }
    }
}