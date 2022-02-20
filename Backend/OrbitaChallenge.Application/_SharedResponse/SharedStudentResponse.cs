using OrbitaChallenge.Domain.StudentAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitaChallenge.Application._SharedResponse
{
    public class SharedStudentResponse
    {
        public SharedStudentResponse() { }
        public SharedStudentResponse(Student student)
        {
            Nome = student.Nome;
            Email = student.Email;
            RA = student.RA;
            CPF = student.CPF;
        }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string RA { get; set; }
        public string CPF { get; set; }
    }
}
