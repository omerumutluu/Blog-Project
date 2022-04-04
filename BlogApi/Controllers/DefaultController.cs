using BlogApi.DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public IActionResult EmployeeList()
        {
            using var c = new Context();
            var values = c.Employees.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult EmployeeAdd(Employee employee)
        {
            using var context = new Context();
            context.Add(employee);
            context.SaveChanges();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult EmployeeGet(int id)
        {
            using var context = new Context();
            var employee = context.Employees.Find(id);
            if(employee == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(employee);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult EmployeeDelete(int id)
        {
            using var context = new Context();
            var employeeToDelete = context.Employees.Find(id);
            if (employeeToDelete == null)
            {
                return NotFound();
            }
            else
            {
                context.Remove(employeeToDelete);
                context.SaveChanges();
                return Ok(employeeToDelete.Id + " id numaralı "+ employeeToDelete.Name + " isimli kullanıcı başarıyla silindi");
            }
        }

        [HttpPut]
        public IActionResult EmployeeUpdate(Employee employee)
        {
            using var context = new Context();
            var employeeToUpdate = context.Employees.Find(employee.Id);
            if (employeeToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                employeeToUpdate.Name = employee.Name;
                context.Update(employeeToUpdate);
                context.SaveChanges();
                return Ok();
            }
        }
    }
}
