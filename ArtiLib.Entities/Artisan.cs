using ArtiLib.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtiLib.Entites
{
    [Table(nameof(Artisan))]
    public class Artisan : Personne
    {
        [Display(Name = "Raison Sociale")]
        [Column(nameof(RaisonSociale))]
        public string RaisonSociale { get; set; }
    }
}