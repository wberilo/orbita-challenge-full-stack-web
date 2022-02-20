using MediatR;
using OrbitaChallenge.Application._SharedResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitaChallenge.Application.Queries.GetStudentByRA
{
    public class GetStudentByRAQueryInput : IRequest<SharedStudentResponse>
    {
        public GetStudentByRAQueryInput(string rA)
        {
            RA = rA;
        }
        public string RA { get; init; }
    }
}
