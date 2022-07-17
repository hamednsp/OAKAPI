using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OAKAPI.Model;

namespace OAKAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        public IActionResult GetPersons()
        {
            var db = new APIDbContext();
            var list = db.Persons
                .Include(x => x.Salary)
                .Include(x => x.Position)
                .ThenInclude(x => x.Department)
                .Select(x => new PersonAll()
                {
                    Id = x.Id,
                    Name = x.Name,
                    PositionName = x.Position.Name,
                    Salary = x.Salary.Amount,
                    DepartmentName = x.Position.Department.DepartmentName
                }).ToList();
            return Ok(list);
        }
        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            var _db = new APIDbContext();
            var result = _db.Persons.FirstOrDefault(x => x.Id == Id);
            if (result == null)
            {
                return NotFound("Id NOT FOUND");
            }

            return Ok(result);
        }
        [HttpPost]
        public IActionResult Post(Person person)
        {
            if (ModelState.IsValid)
            {
                var _db = new APIDbContext();
                _db.Persons.Add(person);
                _db.SaveChanges();
                return Created("Done", person);
            }

            return BadRequest();
        }
        [HttpPut]
        public IActionResult UpdatePerson(Person person)
        {
            if (ModelState.IsValid && person.Id!=0)
            {
                var _db = new APIDbContext();
                Person updatePerson = _db.Persons.Find(person.Id);
                updatePerson.Name = person.Name;
                updatePerson.Surname = person.Surname;
                updatePerson.Passwor = person.Passwor;
                updatePerson.Age = person.Age;
                updatePerson.Email = person.Email;
                updatePerson.Address = person.Address;
                updatePerson.PositionId = person.PositionId;
                updatePerson.SalaryID = person.SalaryID;
                _db.SaveChanges();
                return NoContent();
            }

            return BadRequest();
        }
    }



}

