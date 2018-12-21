namespace ProjektniCentar_Projekat.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Skola")]
    public partial class Skola
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Skola()
        {
            ListaKontakts = new HashSet<ListaKontakt>();
        }

        [Key]
        public int IDSkola { get; set; }

        [Required(ErrorMessage = "Polje je obavezno.")]
        [StringLength(50)]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Nije moguce unositi brojeve i specijalne znakove.")]
        public string NazivSkole { get; set; }

        [Required(ErrorMessage = "Polje je obavezno.")]
        [StringLength(50)]
        public string Adresa { get; set; }

        [Required(ErrorMessage = "Polje je obavezno.")]
        [StringLength(50)]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Nije moguce unositi brojeve i specijalne znakove.")]
        public string Opstina { get; set; }

        [Required(ErrorMessage = "Polje je obavezno.")]
        public int PostanskiBroj { get; set; }

        [Required(ErrorMessage = "Polje je obavezno.")]
        public int MaticniBroj { get; set; }

        [Required(ErrorMessage = "Polje je obavezno.")]
        public int PIB { get; set; }

        [Required(ErrorMessage = "Polje je obavezno.")]
        [StringLength(50)]
        public string BrojRacuna { get; set; }

        [StringLength(200)]
        [Url(ErrorMessage = "Web adresa nije validna. Primer(http://www.google.com)")]
        public string WebStranica { get; set; }

        [Column(TypeName = "image")]
        public byte[] Fotografija { get; set; }

        [StringLength(500)]
        public string Beleske { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ListaKontakt> ListaKontakts { get; set; }
    }
}
