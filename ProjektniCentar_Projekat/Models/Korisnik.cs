namespace ProjektniCentar_Projekat.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Korisnik")]
    public partial class Korisnik
    {
        [Key]
        public int IDKorisnik { get; set; }

        [Required(ErrorMessage = "Polje je obavezno.")]
        [StringLength(50)]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Nije moguce unositi brojeve i specijalne znakove.")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Polje je obavezno.")]
        [StringLength(50)]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Nije moguce unositi brojeve i specijalne znakove.")]
        public string Prezime { get; set; }

        [Required(ErrorMessage = "Polje je obavezno.")]
        [StringLength(50)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Polje je obavezno.")]
        [StringLength(50)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Polje je obavezno.")]
        [StringLength(50)]
        [EmailAddress(ErrorMessage = "Email adresa nije validna.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Polje je obavezno.")]
        [StringLength(50)]
        public string PravoPristupa { get; set; }
    }
}
