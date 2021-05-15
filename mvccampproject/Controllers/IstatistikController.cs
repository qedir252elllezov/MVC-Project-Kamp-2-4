using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.Concrate;

namespace mvccampproject.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        Context c = new Context();
        public ActionResult Index()
        {
            ViewBag.d1 = c.Catagories.Count();
            var value1 = c.Catagories.Where(a => a.CatagoryName == "Yazilim").Single().CatagoryID;
            ViewBag.d2 = c.Headings.Where(a => a.CatagoryID == value1).Count();
            ViewBag.d3 = (from x in c.Writers where x.WriterName.Contains("a") select x.WriterName).ToList().Count.ToString();
            var value2 = c.Headings.GroupBy(x => x.CatagoryID).OrderByDescending(y => y.Count()).Select(z => z.Key).FirstOrDefault();
            ViewBag.d4 = c.Catagories.Where(a => a.CatagoryID == value2).Single().CatagoryName;
            ViewBag.d5 = c.Catagories.Count(x => x.CatagoryStatus == true) - c.Catagories.Count(x => x.CatagoryStatus == false);
            return View();
        }
    }
}