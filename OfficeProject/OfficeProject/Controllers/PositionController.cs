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
            return View();
        }

        //Add Job Position
        public ActionResult AddJobPosition(Puesto puesto)
        {
            return View();
        }

        //Update Job Position
        public ActionResult UpdateJobPosition(int id)
        {
            return View();
        }

        //Update Job Position
        public ActionResult UpdateJobPosition(Puesto puesto)
        {
            return View();
        }

        //Show the job position detail
        public ActionResult DetailJobPosition()
        {
            return View();
        }

        //Delete Job Position by id
        public ActionResult DeleteJobPosition(int id)
        {
            return View();
        }
    }
}