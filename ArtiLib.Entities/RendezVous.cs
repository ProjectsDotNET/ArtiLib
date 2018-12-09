using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtiLib.Entites
{
    [Table(nameof(RendezVous))]
    public class RendezVous
    {
        [Key]
        [Column(nameof(Id))]
        public int Id { get; set; }

        [Column(nameof(IdClient))]
        public int IdClient { get; set; }

        [Column(nameof(IdDisponibiliteArtisan))]
        public int IdDisponibiliteArtisan { get; set; }

        [Column(nameof(IdStatutRendezVous))]
        public int IdStatutRendezVous { get; set; }

        [Column(nameof(IdRendezVousDeplace))]
        public int IdRendezVousDeplace { get; set; }

        [ForeignKey(nameof(IdClient))]
        public Client Client { get; set; }

        [ForeignKey(nameof(IdDisponibiliteArtisan))]
        public DisponibiliteArtisan DisponibiliteArtisan { get; set; }

        [ForeignKey(nameof(IdStatutRendezVous))]
        public StatutRendezVous StatutRendezVous { get; set; }

        [ForeignKey(nameof(IdRendezVousDeplace))]
        public RendezVous RendezVousDeplace { get; set; }

        public RendezVous()
        {
            Client = new Client();
            DisponibiliteArtisan = new DisponibiliteArtisan();
            StatutRendezVous = new StatutRendezVous();
            RendezVousDeplace = new RendezVous();
        }
    }
}