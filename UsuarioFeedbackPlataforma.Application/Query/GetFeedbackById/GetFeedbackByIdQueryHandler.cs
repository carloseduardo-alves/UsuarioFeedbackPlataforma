using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioFeedbackPlataforma.Application.Dto;
using UsuarioFeedbackPlataforma.Infrastructure.Repository;

namespace UsuarioFeedbackPlataforma.Application.Query.GetFeedbackById
{
    public class GetFeedbackByIdQueryHandler : IRequestHandler<GetFeedbackByIdQuery, FeedbackDto>
    {
        private readonly IFeedbackRepository _repository;

        public GetFeedbackByIdQueryHandler(IFeedbackRepository repository)
        {
            _repository = repository;
        }

        public async Task<FeedbackDto> Handle(GetFeedbackByIdQuery request, CancellationToken cancellationToken)
        {
            var feedback = await _repository.GetByIdFeedbackAsync(request.Id);

            if (feedback == null)
            {
                throw new Exception($"Nenhum feedback com este {feedback} foi encontrado");
            }

            return new FeedbackDto
            {
                Id = feedback.Id,
                UserName = feedback.UserName,
                Message = feedback.Message,
                CreatedAt = feedback.CreatedAt
            };
        }
    }
}
