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

        //Action to Open View
        public ActionResult AddSalary()
        {
            return View();
        }

        //Add Salary
        [HttpPost]
        public ActionResult AddSalary(Salario_base salario)
        {
            try
            {
                using (var db = new pruebaContext())
                {
                    db.Salario_base.Add(salario);
                    db.SaveChanges();
                    return RedirectToAction("ListSalary");
                }
            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }

        //Update 
        public ActionResult UpdateSalary(int id)
        {
            try
            {
                using(var db = new pruebaContext())
                {
                    Salario_base sb = db.Salario_base.Where(a => a.id == id).FirstOrDefault();
                    return View(sb);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Update Salary
        [HttpPost]
        public ActionResult UpdateSalary(Salario_base salario)
        {
            try
            {
                using(var db = new pruebaContext())
                {
                    Salario_base sb = db.Salario_base.Find(salario.id);
                    sb.salario = salario.salario;
                    db.SaveChanges();
                    return RedirectToAction("ListSalary");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Details salary
        public ActionResult SalaryDetails()
        {

            return View();
        }

        //Delete Salary
        public ActionResult DeleteSalary(int id)
        {
            try
            {
                using(var db = new pruebaContext())
                {
                    Salario_base sb = db.Salario_base.Find(id);
                    db.Salario_base.Remove(sb);
                    db.SaveChanges();
                    return RedirectToAction("ListSalary");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}