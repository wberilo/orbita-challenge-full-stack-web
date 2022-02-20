using MediatR;
using OrbitaChallenge.Application._SharedResponse;

namespace OrbitaChallenge.Application.Commands.CreateStudent
{
    public class UpdateStudentCommandInput : IRequest<SharedStudentResponse>
    {
        public UpdateStudentCommandInput(string nome, string email, string rA)
        {
            Nome = nome;
            Email = email;
            RA = rA;
        }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string RA { get; init; }
    }
}
