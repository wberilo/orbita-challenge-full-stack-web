using MediatR;
using OrbitaChallenge.Application._SharedResponse;
using OrbitaChallenge.Infra;
using System.Threading;
using System.Threading.Tasks;

namespace OrbitaChallenge.Application.Queries.GetStudentByRA
{
    public class GetStudentByRAQueryHandler : IRequestHandler<GetStudentByRAQueryInput, SharedStudentResponse>
    {
        private readonly Context _context;
        public GetStudentByRAQueryHandler(Context context)
        {
            _context = context;
        }
        public async Task<SharedStudentResponse> Handle(GetStudentByRAQueryInput request, CancellationToken cancellationToken)
        {
            var student = await _context.Students.FindAsync(new object[] { request.RA }, cancellationToken: cancellationToken);
            if (student is null) return new SharedStudentResponse();
            return new SharedStudentResponse(student);
        }
    }
}
