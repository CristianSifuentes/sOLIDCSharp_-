using Microsoft.AspNetCore.Mvc;

namespace DependencyInversion.Controllers;

[ApiController, Route("student")]
public class StudentController : ControllerBase
{
    private readonly IStudentRepository studentRepository;
    private readonly ILogbook logbook;

    // DIP step 4:
    // StudentController is the high-level component: it owns the API use case.
    // It should not create StudentRepository or Logbook with "new" because those are
    // low-level infrastructure details.
    //
    // Instead, the controller depends on abstractions. At runtime, ASP.NET Core injects
    // the concrete implementations registered in Program.cs.
    public StudentController(IStudentRepository studentRepository, ILogbook logbook)
    {
        this.studentRepository = studentRepository ?? throw new ArgumentNullException(nameof(studentRepository));
        this.logbook = logbook ?? throw new ArgumentNullException(nameof(logbook));
    }

    [HttpGet]
    public IEnumerable<Student> Get()
    {
        logbook.Add("Returning student's list.");
        return studentRepository.GetAll();
    }

    [HttpPost]
    public IActionResult Add([FromBody]Student student)
    {
        if (student is null)
        {
            return BadRequest("A student payload is required.");
        }

        studentRepository.Add(student);
        logbook.Add($"The student {student.Fullname} has been added.");

        return CreatedAtAction(nameof(Get), new { id = student.Id }, student);
    }
}
