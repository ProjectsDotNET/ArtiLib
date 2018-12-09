using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtiLib.Entites
{
    [Table(nameof(StatutRendezVous))]
    public class StatutRendezVous
    {
        [Key]
        [Column(nameof(Id))]
        public int Id { get; set; }

        [Display(Name = "Libellé")]
        [Column(nameof(Libelle))]
        public string Libelle { get; set; }
    }
}