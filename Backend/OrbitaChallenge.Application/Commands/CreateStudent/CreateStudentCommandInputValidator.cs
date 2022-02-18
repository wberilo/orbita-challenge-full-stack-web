using FluentValidation;

namespace OrbitaChallenge.Application.Commands.CreateStudent
{
    public class CreateStudentCommandInputValidator : AbstractValidator<CreateStudentCommandInput>
    {
        public CreateStudentCommandInputValidator()
        {

            RuleFor(student => student.CPF).NotEmpty();
            RuleFor(student => student.CPF).Length(11);
            //  Regex: Match a number only string accepts numbers
            RuleFor(student => student.CPF).Matches("^[0-9]*$");

            RuleFor(student => student.Email).EmailAddress();

            RuleFor(student => student.Nome).NotEmpty();

            RuleFor(student => student.RA).NotEmpty();
            //  Regex: Match a number only string accepts numbers
            RuleFor(student => student.RA).Matches("^[0-9]*$");
        }
    }
}


