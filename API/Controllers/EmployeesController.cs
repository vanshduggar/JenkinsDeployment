using EmployeeCRUDAPI.Models;
using EmployeeCRUDAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCRUDAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        //api/Employee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return  (await _employeeRepository.GetAll()).ToList();
        }
        //api/Employee/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var result = await _employeeRepository.GetById(id);

            if(result == null)
            {
                return NotFound();
            }
            return result;
        }
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            await _employeeRepository.Add(employee);
            return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id},employee);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> PutEmployee(int id,Employee employee)
        {
            if(id != employee.Id)
            {
                return BadRequest();
            }

            var result = await _employeeRepository.Update(id,employee);

            if(result == null)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var result = await _employeeRepository.Delete(id);

            if (result == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
