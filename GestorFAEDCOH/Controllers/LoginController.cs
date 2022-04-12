using GestorFAEDCOH.Models.Base_de_datos;
using GestorFAEDCOH.Models.Extras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static GestorFAEDCOH.Filtros.AdminFilters;

namespace GestorFAEDCOH.Controllers
{
    public class LoginController : Controller
    {
        private USUARIO usuario = new USUARIO();

        [NoLogin]
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Validar(string Email, string Contraseña)
        {
            var rm = usuario.ValidarLogin(Email, Contraseña);

            if (rm.response)
            {
                rm.href = Url.Content("/Default/Index");
            }
            else if (rm.response)
            {
                rm.href = Url.Content("/Login/Index");
            }
            return Json(rm);
        }


        public ActionResult Logout()
        {
            SessionHelper.DestroyUserSession();
            return Redirect("~/Login");
        }
    }
}