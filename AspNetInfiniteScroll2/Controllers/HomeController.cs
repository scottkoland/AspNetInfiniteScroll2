using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspNetInfiniteScroll2.Models;

namespace AspNetInfiniteScroll2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult GetData(int pageIndex, int pageSize)
        {
            System.Threading.Thread.Sleep(4000);
            List<Customer> results;
            using (var db = new NorthwindEntities())
            {
                var query = (from c in db.Customers
                    orderby c.CompanyName ascending
                    select c)
                    .Skip(pageIndex*pageSize)
                    .Take(pageSize);
                results = query.ToList();
            }

            return Json(results, JsonRequestBehavior.AllowGet);
        }
    }
}