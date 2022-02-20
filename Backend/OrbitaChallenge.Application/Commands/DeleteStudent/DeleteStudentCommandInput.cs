using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitaChallenge.Application.Commands.DeleteStudent
{
    public class DeleteStudentCommandInput : IRequest<DeleteStudentCommandResult>
    {
        public DeleteStudentCommandInput(string rA)
        {
            RA = rA;
        }
        public string RA { get; init; }
    }
}
