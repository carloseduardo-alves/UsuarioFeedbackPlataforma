using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioFeedbackPlataforma.Core.Entities;
using UsuarioFeedbackPlataforma.Infrastructure.Repository;

namespace UsuarioFeedbackPlataforma.Application.Commands.DeleteFeedback
{
    public class DeleteFeedbackCommandHandler : IRequestHandler<DeleteFeedbackCommand, Unit>
    {
        private readonly IFeedbackRepository _repository;

        public DeleteFeedbackCommandHandler(IFeedbackRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteFeedbackCommand request, CancellationToken cancellationToken)
        {
            var feedback = await _repository.GetByIdFeedbackAsync(request.Id);

            if (feedback == null)
            {
                throw new Exception($"Nenhum feedback com este {feedback} foi encontrado");
            }

            await _repository.DeleteAsync(request.Id);

            return Unit.Value;
        }
    }
}
