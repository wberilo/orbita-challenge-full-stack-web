using MediatR;
using OrbitaChallenge.Application.Queries.GetAllStudents;

namespace OrbitaChallenge.Application.Queries.GetStudentByRA
{
    public class GetAllStudentsQueryInput : IRequest<GetAllStudentsQueryResult>
    {
        public GetAllStudentsQueryInput()
        {
        }
    }
}
