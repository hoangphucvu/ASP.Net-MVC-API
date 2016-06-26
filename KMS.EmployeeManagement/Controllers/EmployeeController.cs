using KMS.EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace KMS.EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeContext db = new EmployeeContext();
        // GET: Employee
        public ViewResult GetAll()
        {
            var employee = db.Employees.ToList();
            ViewBag.Title = "Employee List";
            return View("EmployeeList", employee);
        }

        public ViewResult PageNotFound()
        {
            return View("~/Views/Shared/_404.cshtml");
        }
    }
}