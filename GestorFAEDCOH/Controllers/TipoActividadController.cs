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
    public class TipoActividadController : Controller
    {
        TIPO_ACTIVIDAD tipo_actividad = new TIPO_ACTIVIDAD();

        // GET: Tipo_Actividad
        public ActionResult Index()
        {
            return View(tipo_actividad.ListarTodo());
        }

        public ActionResult Guardar(TIPO_ACTIVIDAD tipo_actividad)
        {
            if (ModelState.IsValid)
            {
                tipo_actividad.Guardar();
                return Redirect("~/Tipo_Actividad/Index");
            }
            else
            {
                return View("~/Tipo_Actividad/Index");
            }
        }

        public ActionResult EditTipAct(int id = 0)
        {
            return View(id == 0 ? new TIPO_ACTIVIDAD() : tipo_actividad.ObtenerTipo_Actividad(id));
        }

        public ActionResult Eliminar(int id)
        {
            tipo_actividad.ID_TIPO_ACTIVIDAD = id;
            tipo_actividad.Eliminar();
            return Redirect("~/Tipo_Actividad/Index");
        }

        public ActionResult Habilitar(int id)
        {
            tipo_actividad.ID_TIPO_ACTIVIDAD = id;
            tipo_actividad.Habilitar();
            return Redirect("~/Tipo_Actividad/Index");
        }
    }
}