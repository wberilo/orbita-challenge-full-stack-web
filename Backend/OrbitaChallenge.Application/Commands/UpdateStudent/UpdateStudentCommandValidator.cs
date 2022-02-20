using FluentValidation;
using OrbitaChallenge.Application.Commands.CreateStudent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitaChallenge.Application.Commands.UpdateStudent
{
    public class UpdateStudentCommandValidator : AbstractValidator<UpdateStudentCommandInput>
    {
        public UpdateStudentCommandValidator()
        {
            RuleFor(student => student.Email).EmailAddress();

            RuleFor(student => student.Nome).NotEmpty();

            RuleFor(student => student.RA).NotEmpty();
            //  Regex: Match a number only string accepts numbers
            RuleFor(student => student.RA).Matches("^[0-9]*$");
        }
    }
}
