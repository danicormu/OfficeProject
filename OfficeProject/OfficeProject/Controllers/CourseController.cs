using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OfficeProject.Models;

namespace OfficeProject.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult ListCourses()
        {
            try
            {
                using (pruebaContext db = new pruebaContext())
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

        public ActionResult CreateCourse()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCourse(Curso curso)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using(pruebaContext db = new pruebaContext())
                {
                    db.Cursos.Add(curso);
                    db.SaveChanges();
                    return RedirectToAction("ListCourses");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al agregar el Curso", ex);
                return View();
            }
        }

        public ActionResult UpdateCourse(int id)
        {
            try
            {
                using (pruebaContext db = new pruebaContext())
                {
                    Curso cu = db.Cursos.Where(a => a.id == id).FirstOrDefault();
                    return View(cu);
                }
            }
            catch (Exception)
            {

                throw;
            }            
        }

        [HttpPost]
        public ActionResult UpdateCourse(Curso curso)
        {
            try
            {
                using(pruebaContext db = new pruebaContext())
                {
                    Curso cu = db.Cursos.Find(curso.id);
                    cu.NombreCurso = curso.NombreCurso;
                    cu.Puntos = curso.Puntos;
                    db.SaveChanges();
                    return RedirectToAction("ListCourses");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public ActionResult CourseDetails(int id)
        {
            try
            {
                using(pruebaContext db = new pruebaContext())
                {
                    Curso cu = db.Cursos.Find(id);
                    return View(cu);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult DeleteCourse(int id)
        {
            try
            {
                using (pruebaContext db = new pruebaContext())
                {
                    Curso cu = db.Cursos.Find(id);
                    db.Cursos.Remove(cu);
                    db.SaveChanges();
                    return RedirectToAction("ListCourses");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}