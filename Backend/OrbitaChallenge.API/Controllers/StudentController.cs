using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrbitaChallenge.Application.Commands.CreateStudent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrbitaChallenge.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        private readonly IMediator _mediator;

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CreateStudentCommandResult>> CreateStudent(CreateStudentCommandInput commandInput)
        {
            CreateStudentCommandInputValidator validator = new();
            var validation = validator.Validate(commandInput);
            if (!validation.IsValid) return BadRequest(validation.Errors.Select(err => err.ErrorMessage));

            var result = await _mediator.Send(commandInput);
            return Created($"/students/{result.RA}",result);
        }

    }
}
