using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KMS.EmployeeManagement.Controllers
{
    public class ErrorController : Controller
    {
        /// <summary>
        /// handle 404 request
        /// </summary>
        public ViewResult PageNotFound()
        {
            return View("~/Views/Shared/_404.cshtml");
        }
    }
}