using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OfficeProject.Models;

namespace OfficeProject.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //List all departments
        public ActionResult ListDepartment()
        {
            try
            {
                using (var db = new pruebaContext())
                {
                    List<Departamento> list = db.Departamentos.ToList();
                    return View(list);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Action to Open the View 
        public ActionResult AddDepartment()
        {
            return View();
        }

        //Add Department
        [HttpPost]
        public ActionResult AddDepartment(Departamento dep)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                using (var db = new pruebaContext())
                {
                    db.Departamentos.Add(dep);
                    db.SaveChanges();
                    return RedirectToAction("ListDepartment");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al agregar el Curso", ex);
                return View();
            }
        }


        //Update Department
        public ActionResult UpdateDepartment(int id)
        {
            try
            {
                using (var db = new pruebaContext())
                {
                    Departamento dep = db.Departamentos.Where(a => a.id == id).FirstOrDefault();
                    return View(dep);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Update
        [HttpPost]
        public ActionResult UpdateDepartment(Departamento dep)
        {
            try
            {
                using (var db = new pruebaContext())
                {
                    Departamento de = db.Departamentos.Find(dep.id);
                    de.NombreDepartamento = dep.NombreDepartamento;
                    db.SaveChanges();
                    return RedirectToAction("ListDepartment");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Function that shows the details
        public ActionResult DepartmentDetails(int id)
        {
            try
            {
                using (var db = new pruebaContext())
                {
                    Departamento de = db.Departamentos.Find(id);
                    return View(de);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Delete Department
        public ActionResult DeleteDepartment(int id)
        {
            try
            {
                using (var db = new pruebaContext())
                {
                    Departamento de = db.Departamentos.Find(id);
                    db.Departamentos.Remove(de);
                    db.SaveChanges();
                    return RedirectToAction("ListDepartment");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    
}