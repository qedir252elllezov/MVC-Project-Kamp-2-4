using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntitFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;

namespace mvccampproject.Controllers
{
    public class CatagoryController : Controller
    {
        CatagoryManager cm = new CatagoryManager(new EfCatagoryDal());
        // GET: Catagory
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetCatagoryList()
        {
            var catagoryvalues = cm.GetList();
            return View(catagoryvalues);
        }
        [HttpGet]
        public ActionResult AddCatagory()
        {
            return View();
        }


     [HttpPost]
        public ActionResult AddCatagory(Catagory p)
        {
            // cm.CatagoryADDBl(p);
            CatagoryValidator catagoryValidator = new CatagoryValidator();
            ValidationResult results = catagoryValidator.Validate(p);
            if(results.IsValid) {
                cm.CatagoryAddBL(p);
                return RedirectToAction("GetCatagoryList");
            }
            else {
                foreach(var item in results.Errors) {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}