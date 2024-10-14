using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioFeedbackPlataforma.Application.Dto;
using UsuarioFeedbackPlataforma.Infrastructure.Repository;

namespace UsuarioFeedbackPlataforma.Application.Query.GetAllFeedback
{
    public class GetAllFeedbacksQueryHandler : IRequestHandler<GetAllFeedbackQuery, IEnumerable<FeedbackDto>>
    {
        private readonly IFeedbackRepository _repository;

        public GetAllFeedbacksQueryHandler(IFeedbackRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<FeedbackDto>> Handle(GetAllFeedbackQuery request, CancellationToken cancellationToken)
        {
            var feedback = await _repository.GetAllFeedbackAsync();

            return feedback.Select(feedback => new FeedbackDto
            {
                Id = feedback.Id,
                UserName = feedback.UserName,
                Message = feedback.Message,
                CreatedAt = feedback.CreatedAt
            });
        }
    }
}
