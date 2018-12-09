using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtiLib.Entites
{
    [Table(nameof(PrestationArtisan))]
    public class PrestationArtisan
    {
        [Key]
        [Column(nameof(Id))]
        public int Id { get; set; }

        [Column(nameof(IdPrestation))]
        public int IdPrestation { get; set; }

        [Column(nameof(IdArtisan))]
        public int IdArtisan { get; set; }

        [Column(nameof(Tarif))]
        public double Tarif { get; set; }

        [Column(nameof(Reduction))]
        public double Reduction { get; set; }

        [Column(nameof(CourteDescription))]
        public string CourteDescription { get; set; }

        [Column(nameof(LongueDescription))]
        public string LongueDescription { get; set; }

        [ForeignKey(nameof(IdPrestation))]
        public Prestation Prestation { get; set; }

        [ForeignKey(nameof(IdArtisan))]
        public Artisan Artisan { get; set; }

        public PrestationArtisan()
        {
            Prestation = new Prestation();
            Artisan = new Artisan();
        }
    }
}