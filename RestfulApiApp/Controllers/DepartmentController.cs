using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestfulApiApp.Controllers
{
    public class DepartmentController : ApiController
    {
        public static List<Department> departments;
        public DepartmentController()
        {
            departments = new List<Department>() {
                new Department{ ID = 1,
                                DepartmentName = "Computer Science",
                                Employees = new List<Employee>{
                                                new Employee{ ID = 1, EmployeeName = "Robert Scott"},
                                                new Employee{ ID = 2, EmployeeName = "Martin Scale"}
                                                            }
                },
                new Department{ ID = 2,
                                DepartmentName = "Mechanical",
                                Employees = new List<Employee>{
                                                new Employee{ ID = 3, EmployeeName = "Indiana Twain"},
                                                new Employee{ ID = 4, EmployeeName = "Tom Spain"}
                                                            }
                }
            };
        }

        /// <summary>
        /// Gets the department collection.
        /// </summary>
        /// <returns>Department collection</returns>
        /// GET: /api/department
        public IEnumerable<Department> Get()
        {
            return departments;
        }

        /// <summary>
        /// Gets the department by id
        /// </summary>
        /// <returns>Ok message and department object if OK, otherwise, not found</returns>
        /// GET: /api/department/id
        //public Department GetDepartmentByID(int id)
        //{
        //    return departments.FirstOrDefault(x => x.ID == id);
        //}

        /// <summary>
        /// Gets the department by id
        /// </summary>
        /// <returns>Ok message and department object if OK, otherwise, not found</returns>
        /// GET: /api/department/id
        public IHttpActionResult GetDepartmentByID(int id)
        {
            var department = departments.FirstOrDefault(x => x.ID == id);
            if (department == null)
            {
                //Return not found result
                return NotFound();
            }
            //Return successful ok result
            return Ok(department);
        }

        /// <summary>
        /// Gets the employees belonging to a department
        /// </summary>
        /// <returns>Employees object with the information</returns>
        /// GET: /api/department/id/employees
        [Route("api/department/{id:int:min(1):max(2):maxlength(1)}/employees")]
        public IEnumerable<Employee> GetEmployeesByDepartmentID(int id)
        {
            return departments.FirstOrDefault(x => x.ID == id).Employees;
        }
    }
}
