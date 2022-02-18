using MediatR;
using OrbitaChallenge.Application.Commands.CreateStudent;
using OrbitaChallenge.Domain.StudentAggregate;
using OrbitaChallenge.Infra;
using System.Threading;
using System.Threading.Tasks;

namespace OrbitaChallenge.Application.Commands
{
    public class CreateStudentHandler : IRequestHandler<CreateStudentCommandInput, CreateStudentCommandResult>
    {
        private readonly Context _context;
        public CreateStudentHandler(Context context)
        {
            _context = context;
        }
        public async Task<CreateStudentCommandResult> Handle(CreateStudentCommandInput request, CancellationToken cancellationToken)
        {
            var student = new Student(request.Nome, request.Email, request.RA, request.CPF);
            _context.Add(student);
            await _context.SaveChangesAsync();
            return new CreateStudentCommandResult(student);
        }
    }
}
