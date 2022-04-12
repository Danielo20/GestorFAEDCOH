namespace GestorFAEDCOH.Models.Base_de_datos
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class bd_FAEDCOH : DbContext
    {
        public bd_FAEDCOH()
            : base("name=bd_FAEDCOH")
        {
        }

        public virtual DbSet<ACTIVIDAD> ACTIVIDAD { get; set; }
        public virtual DbSet<ETAPA> ETAPA { get; set; }
        public virtual DbSet<TIPO_ACTIVIDAD> TIPO_ACTIVIDAD { get; set; }
        public virtual DbSet<TIPO_USUARIO> TIPO_USUARIO { get; set; }
        public virtual DbSet<USUARIO> USUARIO { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ACTIVIDAD>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<ACTIVIDAD>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<ETAPA>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<TIPO_ACTIVIDAD>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<TIPO_ACTIVIDAD>()
                .HasMany(e => e.ACTIVIDAD)
                .WithRequired(e => e.TIPO_ACTIVIDAD)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TIPO_ACTIVIDAD>()
                .HasMany(e => e.ETAPA)
                .WithRequired(e => e.TIPO_ACTIVIDAD)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TIPO_USUARIO>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<TIPO_USUARIO>()
                .HasMany(e => e.USUARIO)
                .WithRequired(e => e.TIPO_USUARIO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.APELLIDO)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.CODIGO)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.TELEFONO)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.PASSWORD)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .HasMany(e => e.ACTIVIDAD)
                .WithRequired(e => e.USUARIO)
                .HasForeignKey(e => e.ID_ENCARGADO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USUARIO>()
                .HasMany(e => e.ACTIVIDAD1)
                .WithRequired(e => e.USUARIO1)
                .HasForeignKey(e => e.ID_AUTOR)
                .WillCascadeOnDelete(false);
        }
    }
}
