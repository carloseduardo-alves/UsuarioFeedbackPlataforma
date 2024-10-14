using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioFeedbackPlataforma.Infrastructure.Repository;

namespace UsuarioFeedbackPlataforma.Application.Commands.UpdateFeedback
{
    public class UpdateFeedbackCommandHandler : IRequestHandler<UpdateFeedbackCommand, Unit>
    {
        private readonly IFeedbackRepository _repository;

        public UpdateFeedbackCommandHandler(IFeedbackRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateFeedbackCommand request, CancellationToken cancellationToken)
        {
            var feedback = await _repository.GetByIdFeedbackAsync(request.Id);

            if (feedback == null)
            {
                throw new Exception($"Nenhum feedback com este {feedback} foi encontrado");
            }

            feedback.UserName = request.Feedback.UserName;
            feedback.Message = request.Feedback.Message;

            await _repository.UpdateAsync(request.Id, feedback);

            return Unit.Value;
        }
    }
}
