using GestorFAEDCOH.Models.Base_de_datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static GestorFAEDCOH.Filtros.AdminFilters;

namespace GestorFAEDCOH.Controllers
{
    [Autenticado]
    public class ActividadController : Controller
    {
        USUARIO usuario = new USUARIO();
        ACTIVIDAD actividad = new ACTIVIDAD();
        TIPO_ACTIVIDAD tipo_actividad = new TIPO_ACTIVIDAD();

        // GET: Actividad
        public ActionResult Index()
        {
            ViewBag.Usuario = usuario.ListarTodo();
            ViewBag.Tipo_Actividad = tipo_actividad.ListarTodo();
            return View(actividad.ListarTodo());
        }

        public ActionResult Guardar(ACTIVIDAD actividad, string daterange)
        {
            if (!actividad.DESCRIPCION.Equals("") && !daterange.Equals(""))
            {
                //split de la fecha
                string[] fechas = daterange.Split('-');
                actividad.FECHA_INICIO = Convert.ToDateTime(fechas[0]);
                actividad.FECHA_FIN = Convert.ToDateTime(fechas[1]);

                actividad.Guardar();
                return Redirect("~/Actividad/Index");
            }
            else
            {
                return View("~/Actividad/Index");
            }
        }

        public ActionResult EditAct(int id = 0)
        {
            ViewBag.Usuario = usuario.ListarTodo();
            ViewBag.Tipo_Actividad = tipo_actividad.ListarTodo();
            return View(id == 0 ? new ACTIVIDAD() : actividad.ObtenerACTIVIDAD(id));
        }

        public ActionResult Eliminar(int id)
        {
            actividad.ID_ACTIVIDAD = id;
            actividad.Eliminar();
            return Redirect("~/Actividad/Index");
        }

        public ActionResult Habilitar(int id)
        {
            actividad.ID_ACTIVIDAD = id;
            actividad.Habilitar();
            return Redirect("~/Actividad/Index");
        }

        public ActionResult Revision(int id)
        {
            actividad.ID_ACTIVIDAD = id;
            actividad.Revision();
            return Redirect("~/Actividad/Index");
        }
    }
}