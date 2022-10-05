using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace tes_verint_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly DataContext _context;

        public EmployeesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<employees>>> Get()
        {
            return Ok(await _context.Employees.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<employees>> Get(int id)
        {
            var emp = await _context.Employees.FindAsync(id);
            if(emp == null)
                return BadRequest("Employee Not Found");
            return Ok(emp);
        }

        [HttpPost]
        public async Task<ActionResult<List<employees>>> AddEmployee(employees emp )
        {
            _context.Employees.Add(emp);
            await _context.SaveChangesAsync();
            return Ok(await _context.Employees.ToListAsync());

        }

        [HttpPut]
        public async Task<ActionResult<List<employees>>> EditEmployee(employees emp)
        {
            var dbEmployee = await _context.Employees.FindAsync(emp.Id);
            if (dbEmployee == null)
                return BadRequest("Employee Not Found");

            dbEmployee.Name = emp.Name;
            dbEmployee.Email = emp.Email;
            dbEmployee.phoneNumber = emp.phoneNumber;
            dbEmployee.hireDate = emp.hireDate;
            dbEmployee.salary = emp.salary;

            await _context.SaveChangesAsync();

            return Ok(await _context.Employees.ToListAsync());

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<employees>> Delete(int id)
        {
            var emp = await _context.Employees.FindAsync(id);
            if (emp == null)
                return BadRequest("Employee Not Found");

            _context.Employees.Remove(emp);
            await _context.SaveChangesAsync();

            return Ok(await _context.Employees.ToListAsync());
        }
    }
}
