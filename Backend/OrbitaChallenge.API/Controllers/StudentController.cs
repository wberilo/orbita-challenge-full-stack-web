using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrbitaChallenge.API.Requests;
using OrbitaChallenge.Application._SharedResponse;
using OrbitaChallenge.Application.Commands.CreateStudent;
using OrbitaChallenge.Application.Commands.DeleteStudent;
using OrbitaChallenge.Application.Commands.UpdateStudent;
using OrbitaChallenge.Application.Queries.GetAllStudents;
using OrbitaChallenge.Application.Queries.GetStudentByRA;
using OrbitaChallenge.Domain.StudentAggregate;
using OrbitaChallenge.Infra;
using System.Linq;
using System.Threading.Tasks;

namespace OrbitaChallenge.API.Controllers
{

    [Route("students")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly Context _context;
        public StudentController(IMediator mediator, Context context)
        {
            _context = context;
            _mediator = mediator;
        }
        private readonly IMediator _mediator;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GetAllStudentsQueryResult>> GetAllStudents()
        {
            return await _mediator.Send(new GetAllStudentsQueryInput());
        }

        [HttpGet]
        [Route("{RA}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SharedStudentResponse>> GetStudentByRA(string RA)
        {
            var response = await _mediator.Send(new GetStudentByRAQueryInput(RA));
            if (response.RA is null) return NotFound();
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SharedStudentResponse>> CreateStudent(CreateStudentCommandInput commandInput)
        {
            CreateStudentCommandValidator validator = new(_context);
            var validation = validator.Validate(commandInput);
            if (!validation.IsValid) return BadRequest(validation.Errors.Select(err => err.ErrorMessage));

            var result = await _mediator.Send(commandInput);
            return Created($"/students/{result.RA}",result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("{RA}")]
        public async Task<ActionResult<SharedStudentResponse>> UpdateStudent([FromRoute] string RA, [FromBody] UpdateStudentRequest req )
        {
            var commandInput = new UpdateStudentCommandInput(req.Nome, req.Email, RA);
            UpdateStudentCommandValidator validator = new();
            var validation = validator.Validate(commandInput);
            if (!validation.IsValid) return BadRequest(validation.Errors.Select(err => err.ErrorMessage));

            var response = await _mediator.Send(commandInput);
            if (response.RA is null) return NotFound();
            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("{RA}")]
        public async Task<ActionResult<DeleteStudentCommandInput>> DeleteStudent([FromRoute] string RA)
        {
            var commandInput = new DeleteStudentCommandInput(RA);
            await _mediator.Send(commandInput);
            return Ok();
        }
    }
}
