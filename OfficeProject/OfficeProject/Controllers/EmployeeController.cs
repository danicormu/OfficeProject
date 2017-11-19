﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OfficeProject.Models;

namespace OfficeProject.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //List all employees
        public ActionResult ListEmployees()
        {
            try
            {
                using(var db = new pruebaContext())
                {
                    List<Empleado> list = db.Empleados.ToList();
                    return View(list);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Add an employee
        public ActionResult AddEmployee(Empleado empleado)
        {
            return View();
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