using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace solicita_web_net.Controllers
{
    public class HomeController : Controller
    {
        
        [Authorize(Roles = "ROLE_ADMINISTRADOR,ROLE_USUARIO_COMUM")]

        public ActionResult Index()
        {
            return View();
        }

        
    }
}