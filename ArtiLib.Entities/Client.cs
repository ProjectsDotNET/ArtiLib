using ArtiLib.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtiLib.Entites
{
    [Table(nameof(Client))]
    public class Client : Personne
    {
    }
}