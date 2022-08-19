using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolApi.Models;

namespace SchoolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly SchoolApiContext _context;
        public CoursesController(SchoolApiContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            return await _context.Courses.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCoursesById(int id)
        {
            var course = await _context.Courses.Where(c => c.Id.Equals(id)).FirstOrDefaultAsync();
            if (course == null)
            {
                return NotFound();
            }
            return course;
        }
        [HttpPost]
        public async Task<ActionResult<Course>> CreateCouse(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCoursesById), new { id = course.Id }, course);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        // return new List<string>() { "c#", "Sql" };
        // }
    }
}
