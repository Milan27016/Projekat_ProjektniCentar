namespace ProjektniCentar_Projekat.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ListaMail")]
    public partial class ListaMail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ListaMail()
        {
            ListaKontakts = new HashSet<ListaKontakt>();
        }

        [Key]
        public int IDMail { get; set; }

        [StringLength(50)]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Nije moguce unositi brojeve i specijalne znakove.")]
        public string Tip { get; set; }

        [Required(ErrorMessage = "Polje je obavezno.")]
        [StringLength(50)]
        [EmailAddress(ErrorMessage = "Email adresa nije validna.")]
        public string Adresa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ListaKontakt> ListaKontakts { get; set; }
    }
}
