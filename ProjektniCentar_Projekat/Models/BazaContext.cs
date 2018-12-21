namespace ProjektniCentar_Projekat.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BazaContext : DbContext
    {
        public static bool admin;

        public BazaContext()
            : base("name=Baza")
        {
        }

        public virtual DbSet<Korisnik> Korisniks { get; set; }
        public virtual DbSet<ListaKontakt> ListaKontakts { get; set; }
        public virtual DbSet<ListaMail> ListaMails { get; set; }
        public virtual DbSet<ListaTelefon> ListaTelefons { get; set; }
        public virtual DbSet<Skola> Skolas { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ListaKontakt>()
                .HasMany(e => e.ListaMails)
                .WithMany(e => e.ListaKontakts)
                .Map(m => m.ToTable("KontaktXrefMail").MapLeftKey("IDKontakt").MapRightKey("IDMail"));

            modelBuilder.Entity<ListaKontakt>()
                .HasMany(e => e.ListaTelefons)
                .WithMany(e => e.ListaKontakts)
                .Map(m => m.ToTable("KontaktXrefTelefon").MapLeftKey("IDKontakt").MapRightKey("IDTelefon"));

            modelBuilder.Entity<ListaKontakt>()
                .HasMany(e => e.Skolas)
                .WithMany(e => e.ListaKontakts)
                .Map(m => m.ToTable("SkolaXrefKontakt").MapLeftKey("IDKontakt").MapRightKey("IDSkola"));
        }
    }
}
