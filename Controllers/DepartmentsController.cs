using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OAKAPI.Model;

namespace OAKAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var db = new APIDbContext();
            var list = db.Departments.ToList();
            return Ok(list);
        }
        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            var _db = new APIDbContext();
            var result = _db.Departments.Find(Id);
            if (result==null)
            {
                return NotFound("Id not found");
            }
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddDepartment(Department department)
        {
            if (ModelState.IsValid)
            {
                var _db = new APIDbContext();
                _db.Add(department);
                _db.SaveChanges();
                return Created("Done", department);
            }

            return BadRequest("InValid input");
        }
        [HttpPut]
        public IActionResult UpdatDepartment(Department department)
        {
            if (ModelState.IsValid)
            {
                var _db = new APIDbContext();
                Department updateDepartment = _db.Departments.Find(department.DepartmentId);
                updateDepartment.DepartmentName = department.DepartmentName;
                _db.SaveChanges();
                return NoContent();
            }

            return BadRequest();
        }
    }
}
