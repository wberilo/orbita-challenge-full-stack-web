using MediatR;
using OrbitaChallenge.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrbitaChallenge.Application.Commands.DeleteStudent
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommandInput, DeleteStudentCommandResult>
    {
        private readonly Context _context;
        public DeleteStudentCommandHandler(Context context)
        {
            _context = context;
        }
        public async Task<DeleteStudentCommandResult> Handle(DeleteStudentCommandInput request, CancellationToken cancellationToken)
        {
            var student = await _context.Students.FindAsync(new object[] { request.RA }, cancellationToken: cancellationToken);
            if (student is null) return new DeleteStudentCommandResult();
            _context.Students.Remove(student);
            await _context.SaveChangesAsync(cancellationToken);
            return new DeleteStudentCommandResult();
        }
    }
}
