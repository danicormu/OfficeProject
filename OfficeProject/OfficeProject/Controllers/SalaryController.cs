using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OfficeProject.Models;

namespace OfficeProject.Controllers
{
    public class SalaryController : Controller
    {
        // GET: Salary
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //List Salary
        public ActionResult ListSalary()
        {
            try
            {
                using (var db = new pruebaContext())
                {
                    List<Salario_base> list = db.Salario_base.ToList();
                    return View(list);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Add Salary
        public ActionResult AddSalary(Salario_base sb)
        {
            return View();
        }

        //Update 
        public ActionResult UpdateSalary(int id)
        {
            return View();
        }

        //Update Salary
        public ActionResult UpdateSalary(Salario_base sb)
        {
            return View();
        }

        //Details salary
        public ActionResult SalaryDetails()
        {
            return View();
        }

        //Delete Salary
        public ActionResult DeleteSalary()
        {
            return View();
        }
    }
}