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

        // api Get: /api/department
        public IEnumerable<Department> Get()
        {
            return departments;
        }

        // api Get: /api/department/id
        public Department GetDepartmentByID(int id)
        {
            return departments.FirstOrDefault(x => x.ID == id);
        }

        // api Get: /api/department/id/employees
        [Route("api/department/{id:int:min(1):max(2):maxlength(1)}/employees")]
        public IEnumerable<Employee> GetEmployeesByDepartmentID(int id)
        {
            return departments.FirstOrDefault(x => x.ID == id).Employees;
        }
    }
}
