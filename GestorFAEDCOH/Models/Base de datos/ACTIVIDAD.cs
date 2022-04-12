namespace GestorFAEDCOH.Models.Base_de_datos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("ACTIVIDAD")]
    public partial class ACTIVIDAD
    {
        [Key]
        public int ID_ACTIVIDAD { get; set; }

        [Required]
        [StringLength(50)]
        public string NOMBRE { get; set; }

        [Required]
        [StringLength(60)]
        public string DESCRIPCION { get; set; }

        public int ID_AUTOR { get; set; }

        public int ID_TIPO_ACTIVIDAD { get; set; }

        public bool? ESTADO { get; set; }

        public int ID_ENCARGADO { get; set; }

        [Column(TypeName = "date")]
        public DateTime FECHA_INICIO { get; set; }

        [Column(TypeName = "date")]
        public DateTime FECHA_FIN { get; set; }

        public virtual USUARIO USUARIO { get; set; }

        public virtual TIPO_ACTIVIDAD TIPO_ACTIVIDAD { get; set; }

        public virtual USUARIO USUARIO1 { get; set; }

        public List<ACTIVIDAD> ListarTodo()
        {
            var ACTIVIDAD = new List<ACTIVIDAD>();

            try
            {
                using (var db = new bd_FAEDCOH())
                {
                    ACTIVIDAD = db.ACTIVIDAD.Include("TIPO_ACTIVIDAD")
                        .Include("USUARIO")
                        .ToList();
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return ACTIVIDAD;
        }

        public void Guardar()
        {
            try
            {
                using (var db = new bd_FAEDCOH())
                {
                    if (this.ID_ACTIVIDAD > 0)
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

        public ACTIVIDAD ObtenerACTIVIDAD(int id)
        {
            var ACTIVIDAD = new ACTIVIDAD();

            try
            {
                using (var db = new bd_FAEDCOH())
                {
                    ACTIVIDAD = db.ACTIVIDAD
                        .Where(x => x.ID_ACTIVIDAD == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return ACTIVIDAD;
        }

        public void Eliminar()
        {
            var ACTIVIDAD = ObtenerACTIVIDAD(ID_ACTIVIDAD);
            this.ID_ACTIVIDAD = ACTIVIDAD.ID_ACTIVIDAD;
            this.NOMBRE = ACTIVIDAD.NOMBRE;
            this.DESCRIPCION = ACTIVIDAD.DESCRIPCION;
            this.ID_AUTOR = ACTIVIDAD.ID_AUTOR;
            this.ID_TIPO_ACTIVIDAD = ACTIVIDAD.ID_TIPO_ACTIVIDAD;
            this.ESTADO = ACTIVIDAD.ESTADO;
            this.ID_ENCARGADO = ACTIVIDAD.ID_ENCARGADO;
            this.FECHA_INICIO = ACTIVIDAD.FECHA_INICIO;
            this.FECHA_FIN = ACTIVIDAD.FECHA_FIN;
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
            var ACTIVIDAD = ObtenerACTIVIDAD(ID_ACTIVIDAD);
            this.ID_ACTIVIDAD = ACTIVIDAD.ID_ACTIVIDAD;
            this.NOMBRE = ACTIVIDAD.NOMBRE;
            this.DESCRIPCION = ACTIVIDAD.DESCRIPCION;
            this.ID_AUTOR = ACTIVIDAD.ID_AUTOR;
            this.ID_TIPO_ACTIVIDAD = ACTIVIDAD.ID_TIPO_ACTIVIDAD;
            this.ESTADO = ACTIVIDAD.ESTADO;
            this.ID_ENCARGADO = ACTIVIDAD.ID_ENCARGADO;
            this.FECHA_INICIO = ACTIVIDAD.FECHA_INICIO;
            this.FECHA_FIN = ACTIVIDAD.FECHA_FIN;
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

        public void Revision()
        {
            var ACTIVIDAD = ObtenerACTIVIDAD(ID_ACTIVIDAD);
            this.ID_ACTIVIDAD = ACTIVIDAD.ID_ACTIVIDAD;
            this.NOMBRE = ACTIVIDAD.NOMBRE;
            this.DESCRIPCION = ACTIVIDAD.DESCRIPCION;
            this.ID_AUTOR = ACTIVIDAD.ID_AUTOR;
            this.ID_TIPO_ACTIVIDAD = ACTIVIDAD.ID_TIPO_ACTIVIDAD;
            this.ESTADO = ACTIVIDAD.ESTADO;
            this.ID_ENCARGADO = ACTIVIDAD.ID_ENCARGADO;
            this.FECHA_INICIO = ACTIVIDAD.FECHA_INICIO;
            this.FECHA_FIN = ACTIVIDAD.FECHA_FIN;
            this.ESTADO = null;
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
