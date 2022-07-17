using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OAKAPI.Model;

namespace OAKAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalariesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var _db = new APIDbContext();
            List<Salary> salaries = _db.Salaries.ToList();
            return Ok(salaries);
        }
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            var _db = new APIDbContext();
            Salary salary = _db.Salaries.Find(Id);
            if (salary!=null)
            {
                _db.Salaries.Remove(salary);
                _db.SaveChanges();
                return NoContent();
            }

            return BadRequest();
        }
    }
}
