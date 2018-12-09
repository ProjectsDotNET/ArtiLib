using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtiLib.Entites
{
    [Table(nameof(Avis))]
    public class Avis
    {
        [Key]
        [Column(nameof(Id))]
        public int Id { get; set; }

        [Display(Name = "Nombre étoile")]
        [Column(nameof(NombreEtoile))]
        public int NombreEtoile { get; set; }

        [Display(Name = nameof(Commentaire))]
        [Column(nameof(Commentaire))]
        public string Commentaire { get; set; }

        [Column(nameof(IdPrestationArtisan))]
        public int IdPrestationArtisan { get; set; }

        [ForeignKey("IdPrestationArtisan")]
        public PrestationArtisan PrestationArtisan { get; set; }

        public Avis()
        {
            PrestationArtisan = new PrestationArtisan();
        }
    }
}