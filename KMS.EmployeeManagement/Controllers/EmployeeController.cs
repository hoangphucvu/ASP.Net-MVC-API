using KMS.EmployeeManagement.Models;
using System.Linq;
using System.Web.Mvc;

namespace KMS.EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeContext db = new EmployeeContext();

        /// <summary>
        /// Return all employee
        /// </summary>
        public ViewResult GetAll()
        {
            var employee = db.Employees.ToList();
            ViewBag.Title = "Employee List";
            return View("EmployeeList", employee);
        }
        /// <summary>
        /// Return view to add new employee
        /// </summary>
        public ViewResult NewEmployee()
        {
            ViewBag.Title = "New Employee";
            return View();
        }

        /// <summary>
        /// return view to update specific employee
        /// </summary>
        /// <param name="id">Employee ID</param>
        public ActionResult UpdateEmployee(int id)
        {
            var employee = db.Employees.Find(id);
            if (employee != null)
            {
                ViewBag.Title = "Update employee ";
                return View(employee);
            }
            return RedirectToAction("PageNotFound", "Error");
        }
    }
}