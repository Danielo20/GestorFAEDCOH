namespace GestorFAEDCOH.Models.Base_de_datos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("ETAPA")]
    public partial class ETAPA
    {
        [Key]
        public int ID_ETAPA { get; set; }

        [Required]
        [StringLength(40)]
        public string NOMBRE { get; set; }

        public int ID_TIPO_ACTIVIDAD { get; set; }

        public bool? ESTADO { get; set; }

        public virtual TIPO_ACTIVIDAD TIPO_ACTIVIDAD { get; set; }

        public List<ETAPA> ListarTodo()
        {
            var etapa = new List<ETAPA>();

            try
            {
                using (var db = new bd_FAEDCOH())
                {
                    etapa = db.ETAPA.Include("TIPO_ACTIVIDAD").ToList();
                }
            }

            catch (Exception e)

            {
                throw;
            }

            return etapa;
        }

        public void Guardar()
        {
            try
            {
                using (var db = new bd_FAEDCOH())
                {
                    if (this.ID_ETAPA > 0)
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

        public ETAPA ObtenerEtapa(int id)
        {
            var etapa = new ETAPA();

            try
            {
                using (var db = new bd_FAEDCOH())
                {
                    etapa = db.ETAPA
                        .Where(x => x.ID_ETAPA == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return etapa;
        }

        public void Eliminar()
        {
            var etapa = ObtenerEtapa(ID_ETAPA);
            this.ID_ETAPA = etapa.ID_ETAPA;
            this.NOMBRE = etapa.NOMBRE;
            this.ID_TIPO_ACTIVIDAD = etapa.ID_TIPO_ACTIVIDAD;
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
            var etapa = ObtenerEtapa(ID_ETAPA);
            this.ID_ETAPA = etapa.ID_ETAPA;
            this.NOMBRE = etapa.NOMBRE;
            this.ID_TIPO_ACTIVIDAD = etapa.ID_TIPO_ACTIVIDAD;
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
