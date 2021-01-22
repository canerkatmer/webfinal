using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace caner.Controllers
{
    public class OtelSube : Controller
    {
        public ActionResult Index()
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var otelsube = session.Query<Models.Sube>().ToList();
                return View(otelsube);
            }
        }
    }
}