using MediatR;
using Microsoft.AspNetCore.Mvc;
using UsuarioFeedbackPlataforma.Application.Commands.CreateFeedback;
using UsuarioFeedbackPlataforma.Application.Commands.DeleteFeedback;
using UsuarioFeedbackPlataforma.Application.Commands.UpdateFeedback;
using UsuarioFeedbackPlataforma.Application.Dto;
using UsuarioFeedbackPlataforma.Application.Query.GetAllFeedback;
using UsuarioFeedbackPlataforma.Application.Query.GetFeedbackById;

namespace UsuarioFeedbackPlataforma.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeedbackControllers : ControllerBase
    {
        private readonly IMediator _mediator;

        public FeedbackControllers(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeedbackDto>>> GetAllFeedback()
        {
            var feedbacks = await _mediator.Send(new GetAllFeedbackQuery());
            return Ok(feedbacks);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<FeedbackDto>> GetFeedbackById(Guid id)
        {
            var feedback = await _mediator.Send(new GetFeedbackByIdQuery(id));
            return Ok(feedback);
        }

        [HttpPost]
        public async Task<IActionResult> PostFeedback([FromBody] CreateFeedbackCommand command)
        {
            var feedback = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetFeedbackById), new { id = feedback }, feedback);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeedback(Guid id, [FromBody] UpdateFeedbackCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("ID mismatch.");
            }

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFeedback(Guid id)
        {
            var command = new DeleteFeedbackCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
