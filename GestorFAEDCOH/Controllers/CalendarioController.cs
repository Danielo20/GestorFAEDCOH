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
    public class CalendarioController : Controller
    {
        ACTIVIDAD actividad = new ACTIVIDAD();

        // GET: Calendario
        public ActionResult Index()
        {
            return View(actividad.ListarTodo());
        }
    }
}