using FluentValidation;
using OrbitaChallenge.Infra;

namespace OrbitaChallenge.Application.Commands.CreateStudent
{
    public class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommandInput>
    {
        public CreateStudentCommandValidator(Context context)
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


            RuleFor(x => x.RA).Must(RA =>
            {
                var student = context.Students.Find(RA);
                if (student is null) return true;
                return false;
            }).WithMessage("RA já existe").WithErrorCode("AlreadyExists");

        }
    }
}


