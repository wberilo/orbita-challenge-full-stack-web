using MediatR;
using OrbitaChallenge.Application._SharedResponse;
using OrbitaChallenge.Application.Commands.CreateStudent;
using OrbitaChallenge.Infra;
using System.Threading;
using System.Threading.Tasks;

namespace OrbitaChallenge.Application.Commands
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommandInput, SharedStudentResponse>
    {
        private readonly Context _context;
        public UpdateStudentCommandHandler(Context context)
        {
            _context = context;
        }
        public async Task<SharedStudentResponse> Handle(UpdateStudentCommandInput request, CancellationToken cancellationToken)
        {
            var student = await _context.Students.FindAsync(new object[] { request.RA }, cancellationToken: cancellationToken);
            if(student is null) return new SharedStudentResponse();
            student.Nome = request.Nome;
            student.Email = request.Email;
            await _context.SaveChangesAsync(cancellationToken);
            return new SharedStudentResponse(student);
        }
    }
}
