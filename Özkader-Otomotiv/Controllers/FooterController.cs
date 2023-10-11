using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Özkader_Otomotiv.Controllers
{
    public class FooterController : Controller
    {
        // GET: Footer
        public PartialViewResult Footer()
        {
            return PartialView();
        }
    }
}