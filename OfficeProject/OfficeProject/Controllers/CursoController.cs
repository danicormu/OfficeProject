using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OfficeProject.Models;

namespace OfficeProject.Controllers
{
    public class CursoController : Controller
    {
        // GET: Curso
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            try
            {
                using (pruebaDBEntities db = new pruebaDBEntities())
                {
                    List<Curso> list = db.Cursos.ToList();
                    return View(list);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult Create(Curso curso)
        {
            try
            {
                using (pruebaDBEntities db = new pruebaDBEntities)
                {
                    db.Cursos.Add(curso);
                    db.SaveChanges();
                    return RedirectToAction("List");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al agregar el Curso", ex);
                return View();
            }
        }
    }
}