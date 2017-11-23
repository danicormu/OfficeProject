using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OfficeProject.Models;

namespace OfficeProject.Controllers
{
    public class EmployeeController : Controller
    {
       
        //List all employees
        public ActionResult ListEmployees()
        {
            try
            {
                pruebaContext db = new pruebaContext();
                List<Empleado> list = db.Empleados.ToList();
                return View(list);
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Action to Open View
        public ActionResult AddEmployee()
        {
            return View();
        }

        //Add an employee
        [HttpPost]
        public ActionResult AddEmployee(Empleado empleado)
        {
            try
            {
                using(var db = new pruebaContext())
                {
                    db.Empleados.Add(empleado);
                    db.SaveChanges();
                    return RedirectToAction("ListEmployees");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Edit an employee
        public ActionResult UpdateEmployee(int id)
        {
            try
            {
                using (var db = new pruebaContext())
                {
                    Empleado emp = db.Empleados.Where(a => a.id == id).FirstOrDefault();
                    return View(emp);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Update an employee
        [HttpPost]
        public ActionResult UpdateEmployee(Empleado empleado)
        {
            try
            {
                using (var db = new pruebaContext())
                {
                    Empleado emp = db.Empleados.Find(empleado.id);
                    emp.NombreEmpleado = empleado.NombreEmpleado;
                    emp.PagoPorPunto = empleado.PagoPorPunto;
                    emp.PorcAdicional = empleado.PorcAdicional;
                    db.SaveChanges();
                    return RedirectToAction("ListEmployees");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Show employee details
        public ActionResult EmployeeDetail(int id)
        {
            return View();
        }

        //Delete an employee
        public ActionResult DeleteEmployee(int id)
        {
            try
            {
                using (var db = new pruebaContext())
                {
                    Empleado emp = db.Empleados.Find(id);
                    db.Empleados.Remove(emp);
                    db.SaveChanges();
                    return RedirectToAction("ListEmployees");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}