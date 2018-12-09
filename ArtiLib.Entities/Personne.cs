using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtiLib.Entities
{
    public class Personne
    {
        [Key]
        [Column(nameof(Id))]
        public int Id { get; set; }

        [Display(Name = nameof(Nom))]
        [Column(nameof(Nom))]
        public string Nom { get; set; }

        [Display(Name = "Prénom")]
        [Column(nameof(Prenom))]
        public string Prenom { get; set; }

        [Display(Name = "Date Naissance")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Column(nameof(DateNaissance))]
        public DateTime DateNaissance { get; set; }

        [Display(Name = "Téléphone")]
        [Column(nameof(Tel))]
        public string Tel { get; set; }

        [Display(Name = nameof(Mail))]
        [Column(nameof(Mail))]
        public string Mail { get; set; }

        [Display(Name = nameof(Adresse))]
        [Column(nameof(Adresse))]
        public string Adresse { get; set; }

        [Display(Name = "Code Postal")]
        [Column("CodePostal")]
        public string CodePostal { get; set; }

        [Display(Name = nameof(Ville))]
        [Column(nameof(Ville))]
        public string Ville { get; set; }

        public string FullName
        {
            get
            {
                return Prenom + " " + Nom;
            }
        }
    }
}