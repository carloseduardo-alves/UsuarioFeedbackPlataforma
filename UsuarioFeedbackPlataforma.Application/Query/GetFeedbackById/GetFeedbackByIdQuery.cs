using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioFeedbackPlataforma.Application.Dto;

namespace UsuarioFeedbackPlataforma.Application.Query.GetFeedbackById
{
    public class GetFeedbackByIdQuery : IRequest<FeedbackDto>
    {
        public Guid Id { get; set; }

        public GetFeedbackByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
