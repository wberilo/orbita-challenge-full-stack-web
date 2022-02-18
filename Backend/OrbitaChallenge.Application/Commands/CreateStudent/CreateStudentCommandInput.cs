using MediatR;

namespace OrbitaChallenge.Application.Commands.CreateStudent
{
    public class CreateStudentCommandInput: IRequest<CreateStudentCommandResult>
    {
        public CreateStudentCommandInput(string nome, string email, string rA, string cPF)
        {
            Nome = nome;
            Email = email;
            RA = rA;
            CPF = cPF;
        }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string RA { get; init; }
        public string CPF { get; init; }
    }
}
