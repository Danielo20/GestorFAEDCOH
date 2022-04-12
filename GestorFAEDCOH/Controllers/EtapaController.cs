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
    public class EtapaController : Controller
    {
        ETAPA etapa = new ETAPA();
        TIPO_ACTIVIDAD tipo_actividad = new TIPO_ACTIVIDAD();

        // GET: Etapa
        public ActionResult Index()
        {
            ViewBag.Tipo_Actividad = tipo_actividad.ListarTodo();
            return View(etapa.ListarTodo());
        }

        public ActionResult Guardar(ETAPA etapa)
        {
            if (ModelState.IsValid)
            {
                etapa.Guardar();
                return Redirect("~/Etapa/Index");
            }
            else
            {
                return View("~/Etapa/Index");
            }
        }

        public ActionResult EditEta(int id = 0)
        {
            ViewBag.Tipo_Actividad = tipo_actividad.ListarTodo();
            return View(id == 0 ? new ETAPA() : etapa.ObtenerEtapa(id));
        }

        public ActionResult Eliminar(int id)
        {
            etapa.ID_ETAPA = id;
            etapa.Eliminar();
            return Redirect("~/Etapa/Index");
        }

        public ActionResult Habilitar(int id)
        {
            etapa.ID_ETAPA = id;
            etapa.Habilitar();
            return Redirect("~/Etapa/Index");
        }
    }
}