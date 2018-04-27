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
using Web_API_Demo_Dev_Day.Models;
using Swashbuckle.Swagger.Annotations;
using System.Web.Http.Results;

namespace Web_API_Demo_Dev_Day.Controllers
{
    public class EmployeesController : ApiController
    {
        private EmployeeDataModel db = new EmployeeDataModel();

        /// <summary>
        /// Gets all Employees
        /// </summary>
        /// <returns>List of Employees</returns>
        // GET: api/Employees
        [SwaggerResponse(HttpStatusCode.OK, "List of Employees", typeof(IEnumerable<int>))]
        public IQueryable<Employee> GetEmployees()
        {
            return db.Employees;
        }

        /// <summary>
        /// Gets an Employee by id
        /// </summary>
        /// <param name="id">Employee id</param>
        /// <returns>An Employee</returns>
        // GET: api/Employees/5
        [SwaggerResponse(HttpStatusCode.OK, "An Employee", typeof(Employee))]
        [SwaggerResponse(HttpStatusCode.NotFound, Type = typeof(NotFoundResult))]
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

        /// <summary>
        /// Updates an Employee
        /// </summary>
        /// <param name="id">Employee id</param>
        /// <param name="employee">Employee object</param>
        /// <returns>No response</returns>
        // PUT: api/Employees/5
        [SwaggerResponse(HttpStatusCode.NoContent)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.NotFound, Type = typeof(NotFoundResult))]
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

        /// <summary>
        /// Creates an Employee
        /// </summary>
        /// <param name="employee">Employee object</param>
        /// <returns>Created Employee</returns>
        /// <response></response>
        // POST: api/Employees
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Created)]
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

        /// <summary>
        /// Deletes an Employee
        /// </summary>
        /// <param name="id">Employee id</param>
        /// <returns>Deleted Employee</returns>
        // DELETE: api/Employees/5
        [SwaggerResponse(HttpStatusCode.OK, "An Employee", typeof(Employee))]
        [SwaggerResponse(HttpStatusCode.NotFound, Type = typeof(NotFoundResult))]
        [ResponseType(typeof(Employee))]
        public IHttpActionResult DeleteEmployee(int id)
        {
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            db.Employees.Remove(employee);
            db.SaveChanges();

            return Ok(employee);
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