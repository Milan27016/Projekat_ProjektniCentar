namespace ProjektniCentar_Projekat.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ListaKontakt")]
    public partial class ListaKontakt
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ListaKontakt()
        {
            ListaMails = new HashSet<ListaMail>();
            ListaTelefons = new HashSet<ListaTelefon>();
            Skolas = new HashSet<Skola>();
        }

        [Key]
        public int IDKontakt { get; set; }

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
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Nije moguce unositi brojeve i specijalne znakove.")]
        public string RadnoMesto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ListaMail> ListaMails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ListaTelefon> ListaTelefons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Skola> Skolas { get; set; }
    }
}
