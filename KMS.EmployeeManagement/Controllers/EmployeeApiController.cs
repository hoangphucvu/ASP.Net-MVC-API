using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using KMS.EmployeeManagement.Models;

namespace KMS.EmployeeManagement.Controllers
{
    public class EmployeeApiController : ApiController
    {
        private EmployeeContext db = new EmployeeContext();

        // GET: api/EmployeeApi
        public IQueryable<Employee> GetEmployees()
        {
            return db.Employees;
        }

        // GET: api/EmployeeApi/5
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

        // PUT: api/EmployeeApi/5
        [HttpPut]
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

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/EmployeeApi
        [HttpPost]
        [ResponseType(typeof(Employee))]
        public IHttpActionResult PostEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.ToString());
            }

            db.Employees.Add(employee);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = employee.ID }, employee);
        }

        // DELETE: api/EmployeeApi/5
        [HttpDelete]
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

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        private bool EmployeeExists(int id)
        {
            return db.Employees.Count(e => e.ID == id) > 0;
        }
    }
}