using MediatR;
using OrbitaChallenge.Application._SharedResponse;
using OrbitaChallenge.Application.Commands.CreateStudent;
using OrbitaChallenge.Domain.StudentAggregate;
using OrbitaChallenge.Infra;
using System.Threading;
using System.Threading.Tasks;

namespace OrbitaChallenge.Application.Commands
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommandInput, SharedStudentResponse>
    {
        private readonly Context _context;
        public CreateStudentCommandHandler(Context context)
        {
            _context = context;
        }
        public async Task<SharedStudentResponse> Handle(CreateStudentCommandInput request, CancellationToken cancellationToken)
        {
            var student = new Student(request.Nome, request.Email, request.RA, request.CPF);
            _context.Add(student);
            await _context.SaveChangesAsync(cancellationToken);
            return new SharedStudentResponse(student);
        }
    }
}
