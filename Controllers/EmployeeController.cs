using EmployeeAdmin.Data;
using EmployeeAdmin.Models;
using EmployeeAdmin.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //localhost:xxxxx/api/employess

    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        //inject in controller by help of this ctor
       
        public EmployeeController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [Route("allUser")]
        [HttpGet]
        //IActionResult give status of http request
        public IActionResult GetAllEmployees() //Employee
        {
            var allEmployee = dbContext.MyProperty.ToList();
            return Ok(allEmployee);
        }

        [Route("{id:guid}")]
        [HttpPost]
        public IActionResult GetEmployee(Guid id) { 
        
            var employee=dbContext.MyProperty.Find(id);
            if (employee == null) {
                return BadRequest("Invalid id");
            }
            return Ok(employee);
        }


        [Route("login")]
        [HttpPost]
        //FormBody bind in json form
        public IActionResult AddEmployee([FromBody] Employee employeeEntity)
        {

            if (employeeEntity == null) {
                return BadRequest("Invalid data");
            }

            dbContext.MyProperty.Add(employeeEntity);
            dbContext.SaveChanges();

            return Ok(employeeEntity);
        }
    }
}
