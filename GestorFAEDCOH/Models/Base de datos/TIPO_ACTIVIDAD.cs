namespace GestorFAEDCOH.Models.Base_de_datos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class TIPO_ACTIVIDAD
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TIPO_ACTIVIDAD()
        {
            ACTIVIDAD = new HashSet<ACTIVIDAD>();
            ETAPA = new HashSet<ETAPA>();
        }

        [Key]
        public int ID_TIPO_ACTIVIDAD { get; set; }

        [StringLength(20)]
        public string DESCRIPCION { get; set; }

        public bool? ESTADO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ACTIVIDAD> ACTIVIDAD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ETAPA> ETAPA { get; set; }

        public List<TIPO_ACTIVIDAD> ListarTodo()
        {
            var tipo_actividad = new List<TIPO_ACTIVIDAD>();

            try
            {
                using (var db = new bd_FAEDCOH())
                {
                    tipo_actividad = db.TIPO_ACTIVIDAD.ToList();
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return tipo_actividad;
        }

        public void Guardar()
        {
            try
            {
                using (var db = new bd_FAEDCOH())
                {
                    if (this.ID_TIPO_ACTIVIDAD > 0)
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    else
                    {
                        db.Entry(this).State = EntityState.Added;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public TIPO_ACTIVIDAD ObtenerTipo_Actividad(int id)
        {
            var tipo_actividad = new TIPO_ACTIVIDAD();

            try
            {
                using (var db = new bd_FAEDCOH())
                {
                    tipo_actividad = db.TIPO_ACTIVIDAD
                        .Where(x => x.ID_TIPO_ACTIVIDAD == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return tipo_actividad;
        }

        public void Eliminar()
        {
            var tipo_actividad = ObtenerTipo_Actividad(ID_TIPO_ACTIVIDAD);
            this.ID_TIPO_ACTIVIDAD = tipo_actividad.ID_TIPO_ACTIVIDAD;
            this.DESCRIPCION = tipo_actividad.DESCRIPCION;
            this.ESTADO = false;
            try
            {
                using (var db = new bd_FAEDCOH())
                {
                    if (this.ID_TIPO_ACTIVIDAD > 0)
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void Habilitar()
        {
            var tipo_actividad = ObtenerTipo_Actividad(ID_TIPO_ACTIVIDAD);
            this.ID_TIPO_ACTIVIDAD = tipo_actividad.ID_TIPO_ACTIVIDAD;
            this.DESCRIPCION = tipo_actividad.DESCRIPCION;
            this.ESTADO = true;
            try
            {
                using (var db = new bd_FAEDCOH())
                {
                    if (this.ID_TIPO_ACTIVIDAD > 0)
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
