using System;
using System.Web.Mvc;

namespace KMS.EmployeeManagement.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Create Error associate with exception handler
        /// </summary>
        /// <returns>exception to server</returns>
        public ActionResult CreateError()
        {
            throw new Exception("For testing purpose");
        }

        /// <summary>
        /// handle 404 request
        /// </summary>
        public ViewResult PageNotFound()
        {
            return View("~/Views/Shared/_404.cshtml");
        }

    }
}