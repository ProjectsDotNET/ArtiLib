using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtiLib.Entites
{
    [Table(nameof(DisponibiliteArtisan))]
    public class DisponibiliteArtisan
    {
        [Key]
        [Column(nameof(Id))]
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Column(nameof(IdArtisan))]
        public int IdArtisan { get; set; }

        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Column(nameof(DateHeure))]
        public DateTime DateHeure { get; set; }

        [ForeignKey(nameof(IdArtisan))]
        public Artisan Artisan { get; set; }

        public DisponibiliteArtisan()
        {
            Artisan = new Artisan();
        }
    }
}