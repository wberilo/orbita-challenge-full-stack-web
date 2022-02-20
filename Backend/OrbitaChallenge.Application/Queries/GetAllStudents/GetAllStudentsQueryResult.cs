using OrbitaChallenge.Application._SharedResponse;
using OrbitaChallenge.Domain.StudentAggregate;
using System.Collections.Generic;

namespace OrbitaChallenge.Application.Queries.GetAllStudents
{
    public class GetAllStudentsQueryResult
    {
        public List<SharedStudentResponse> Items { get; set; }
    }
}
