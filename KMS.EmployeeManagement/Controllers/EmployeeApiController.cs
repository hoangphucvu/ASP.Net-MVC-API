using KMS.EmployeeManagement.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KMS.EmployeeManagement.Controllers
{
    public class EmployeeApiController : ApiController
    {
        private EmployeeContext db = new EmployeeContext();

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            var employee = db.Employees.Find(id);
            if (employee != null)
            {
                return Ok(db.Employees.SingleOrDefault(em => em.ID == id));
            }
            return NotFound();
        }

        [HttpPost]
        // POST api/<controller>
        public HttpResponseMessage Post(Employee employee)
        {
            if (employee != null && ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpPut]
        // PUT api/<controller>/5
        public HttpResponseMessage Put(int id, Employee employee)
        {
            if(employee != null && ModelState.IsValid)
            {
                var specificEmployee = db.Employees.Find(id);
                specificEmployee.StartDate =employee.StartDate;
                specificEmployee.DOB = employee.DOB;
                db.Entry(specificEmployee).State = EntityState.Modified;
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
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