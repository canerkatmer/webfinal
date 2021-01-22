using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace caner.Controllers
{
    public class OtelController : Controller
    {
        public ActionResult Index()
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var oteller = session.Query<Models.Otel>().Fetch(x => x.Subeler).ToList();
                return View(oteller);
            }
        }

        public ActionResult Listele()
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var oteller = session.Query<Models.Otel>().ToList();
                return View(oteller);
            }
        }

        public ActionResult Yeni()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var oteller = session.Query<Models.Otel>().FirstOrDefault(x => x.Id == id);
                return View(oteller);
            }
        }
        public ActionResult Delete(int id)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var yoket= session.Query<Models.Otel>().FirstOrDefault(x => x.Id == id);
                session.Delete(yoket);
                session.Flush();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Models.Otel otel)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var OtelData = session.Query<Models.Otel>().FirstOrDefault(x => x.Id == otel.Id);
                OtelData.Id = otel.Id;
                OtelData.Ad = otel.Ad;
                OtelData.Sehir = otel.Sehir;
                session.SaveOrUpdate(OtelData);
                session.Flush();
                return RedirectToAction("/Index");
            }
        }
    }
}