using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly TestDBContext _context;
        public TestController(TestDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<Dictionary<int, int>> GetDictionary()
        {
            Dictionary<int, int> test = new Dictionary<int, int>();

            for (int i = 0; i < 10; i++)
            {
                test.Add(i + 1, i);
            }

            return test;
        }

        // [HttpGet]
        // public ActionResult<IEnumerable<StudentRegister>> GetTeacher()
        // {
        //     //var query1 = _context.Teachers.ToList();

        //     var query2 = _context.StudentRegisters.ToList();

        //     List<Teacher> list = new List<Teacher>();
        //     List<StudentRegister> list1 = new List<StudentRegister>();

        //     foreach (var item in query2)
        //     {
        //         list1.Add(item);
        //     }

        //     return list1;
        // }

        [HttpPost]
        public async Task<ActionResult<StudentRegister>> AddStudent(StudentRegister student)
        {
            _context.StudentRegisters.Add(student);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentRegister>> GetStudent(int id)
        {
            var student = await _context.StudentRegisters.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }
    }
}