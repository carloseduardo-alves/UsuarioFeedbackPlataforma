using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioFeedbackPlataforma.Core.Entities;
using UsuarioFeedbackPlataforma.Infrastructure.Repository;

namespace UsuarioFeedbackPlataforma.Application.Commands.CreateFeedback
{
    public class CreateFeedbackCommandHandler : IRequestHandler<CreateFeedbackCommand, Guid>
    {
        private readonly IFeedbackRepository _repository;
        private readonly IValidator<CreateFeedbackCommand> _validator;

        public CreateFeedbackCommandHandler(IFeedbackRepository repository, IValidator<CreateFeedbackCommand> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<Guid> Handle(CreateFeedbackCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var feedback = new Feedback(
                Guid.NewGuid(),
                request.Feedback.UserName,
                request.Feedback.Message,
                DateTime.UtcNow
                );

            await _repository.AddAsync(feedback);
            
            return feedback.Id;
        }
    }
}
