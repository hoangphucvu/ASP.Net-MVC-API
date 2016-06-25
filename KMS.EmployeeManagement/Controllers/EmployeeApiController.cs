using KMS.EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web;

namespace KMS.EmployeeManagement.Controllers
{
    public class EmployeeApiController : ApiController
    {
        private EmployeeContext db = new EmployeeContext();

        // GET api/<controller>/5
        public Employee Get(int id)
        {
            return db.Employees.SingleOrDefault(em=>em.ID == id);
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpDelete]
        // DELETE api/<controller>/5
        public void Delete(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                string[] idString = id.Split(new char[] { ',' });
                foreach (var employeeID in idString)
                {
                    var employee = db.Employees.Find((int.Parse(employeeID)));
                    db.Employees.Remove(employee);
                }
                db.SaveChanges();
            }
        }
    }
}