using OrbitaChallenge.Domain.StudentAggregate;

namespace OrbitaChallenge.Application.Commands.CreateStudent
{
    public class CreateStudentCommandResult
    {
        public CreateStudentCommandResult() { }
        public CreateStudentCommandResult(Student student)
        {
            Nome = student.Nome;
            Email = student.Email;
            RA = student.RA;
            CPF = student.CPF;
        }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string RA { get; set; }
        public string CPF { get; set; }
    }
}
