using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OfficeProject.Models;

namespace OfficeProject.Controllers
{
    public class PositionController : Controller
    {
        // GET: Position
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //List all job position
        public ActionResult ListJobPositions()
        {
            try
            {
                using (var db = new pruebaContext())
                {
                    List<Puesto> list = db.Puestos.ToList();
                    return View(list);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Action to Open View
        public ActionResult AddJobPosition()
        {
            return View();
        }

        //Add Job Position
        [HttpPost]
        public ActionResult AddJobPosition(Puesto puesto)
        {
            try
            {
                using(var db = new pruebaContext())
                {
                    db.Puestos.Add(puesto);
                    db.SaveChanges();
                    return RedirectToAction("ListJobPositions");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Update Job Position
        public ActionResult UpdateJobPosition(int id)
        {
            try
            {
                using (var db = new pruebaContext())
                {
                    Puesto pto = db.Puestos.Where(a => a.Id == id).FirstOrDefault();
                    return View(pto);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Update Job Position
        [HttpPost]
        public ActionResult UpdateJobPosition(Puesto puesto)
        {
            try
            {
                using (var db = new pruebaContext())
                {
                    Puesto pto = db.Puestos.Find(puesto.Id);
                    pto.NombrePuesto = puesto.NombrePuesto;
                    pto.IdSalario = puesto.IdSalario;
                    db.SaveChanges();
                    return RedirectToAction("ListJobPosition");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Show the job position detail
        public ActionResult DetailJobPosition()
        {
            return View();
        }

        //Delete Job Position by id
        public ActionResult DeleteJobPosition(int id)
        {
            try
            {
                using(var db = new pruebaContext())
                {
                    Puesto pto = db.Puestos.Find(id);
                    db.Puestos.Remove(pto);
                    db.SaveChanges();
                    return RedirectToAction("ListJobPosition");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}