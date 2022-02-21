using MediatR;
using Microsoft.EntityFrameworkCore;
using OrbitaChallenge.Application._SharedResponse;
using OrbitaChallenge.Application.Queries.GetStudentByRA;
using OrbitaChallenge.Infra;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OrbitaChallenge.Application.Queries.GetAllStudents
{
    public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQueryInput, GetAllStudentsQueryResult>
    {
        private readonly Context _context;
        public GetAllStudentsQueryHandler(Context context)
        {
            _context = context;
        }
        public async Task<GetAllStudentsQueryResult> Handle(GetAllStudentsQueryInput request, CancellationToken cancellationToken)
        {
            var students = await _context.Students.Select(x => new SharedStudentResponse(x)).ToListAsync();

            return new GetAllStudentsQueryResult()
            {
                Items = students
            };
        }
    }
}
