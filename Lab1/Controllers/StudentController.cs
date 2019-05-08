using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private StudentsDbContext context;
        
        public StudentController(StudentsDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Student> GetStudents()
        {
            return context.Students;
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult GetStudent(int id)
        {
            var existing = context.Students.FirstOrDefault(student => student.Id == id);

            if (existing == null)
            {
                return NotFound();
            }

            return Ok(existing);
        }

        [HttpPost]
        public void Post([FromBody] Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Student student)
        {
            var existing = context.Students.AsNoTracking().FirstOrDefault(s => s.Id == id);
            if (existing == null)
            {
                context.Students.Add(student);
                context.SaveChanges();
                return Ok(student);
            }
            student.Id = id;
            context.Students.Update(student);
            context.SaveChanges();
            return Ok(student);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = context.Students.FirstOrDefault(student => student.Id == id);

            if (existing == null)
            {
                return NotFound();
            }
            context.Students.Remove(existing);
            context.SaveChanges();
            return Ok();
        }


    }
}
