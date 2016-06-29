using KMS.EmployeeManagement.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace KMS.EmployeeManagement.Controllers.API_Controller
{
    public class EmployeeController : ApiController
    {
        private EmployeeContext db = new EmployeeContext();

        /// <summary>
        /// Get single employee
        /// </summary>
        /// <param name="id">Employee ID</param>
        /// <returns></returns>
        // GET: api/Employee/5
        [ResponseType(typeof(Employee))]
        public IHttpActionResult GetEmployee(int id)
        {
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // PUT: api/Employee/5
        /// <summary>
        /// Update existing employee
        /// </summary>
        /// <param name="id">Employee ID</param>
        /// <param name="employee">Employee Entities</param>
        /// <returns></returns>
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmployee(int id, Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee.ID)
            {
                return BadRequest();
            }

            db.Entry(employee).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        /// <summary>
        /// Update employee
        /// </summary>
        /// <param name="employee">Employee entites params</param>
        /// <returns></returns>
        // POST: api/Employee
        [ResponseType(typeof(Employee))]
        public IHttpActionResult PostEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Employees.Add(employee);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = employee.ID }, employee);
        }

        // DELETE: api/Employee/5
        /// <summary>
        /// Delete multiple employee
        /// </summary>
        /// <param name="id">Employee ID string</param>
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeExists(int id)
        {
            return db.Employees.Count(e => e.ID == id) > 0;
        }
    }
}