using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OAKAPI.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OAKAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class weatherController : ControllerBase
    {
        // GET: api/<weatherController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            using (APIDbContext _dbContext=new APIDbContext())
            {
                Department department = new Department();
                department.DepartmentName = "department2";
                _dbContext.Add(department);
                _dbContext.SaveChanges();
            }
            return new string[] { "value1", "value2" };
        }

        // GET api/<weatherController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<weatherController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<weatherController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<weatherController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
