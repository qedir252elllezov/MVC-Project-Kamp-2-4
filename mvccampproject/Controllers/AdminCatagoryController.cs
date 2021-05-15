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
    public class AdminCatagoryController : Controller
    {
        CatagoryManager cm = new CatagoryManager(new EfCatagoryDal());
       
        public ActionResult Index()
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
            CatagoryValidator catagoryvalidator = new CatagoryValidator();
            ValidationResult result = catagoryvalidator.Validate(p);
            if(result.IsValid) {
                cm.CatagoryAddBL(p);
                return RedirectToAction("Index");
            }
            else {
                foreach(var item in result.Errors) {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            var catagoryvalue = cm.GetID(id);
            cm.CatagoryDelete(catagoryvalue);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditCatagory(int id)
        {
            var catagoryvalue = cm.GetID(id);
            return View(catagoryvalue);
        }
        [HttpPost]
        public ActionResult EditCatagory(Catagory p)
        {
            cm.CatagoryUpdate(p);
            return RedirectToAction("Index");
        }
    }
}