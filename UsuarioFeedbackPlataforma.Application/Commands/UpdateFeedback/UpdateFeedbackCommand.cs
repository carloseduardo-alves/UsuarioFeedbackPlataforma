using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioFeedbackPlataforma.Application.Dto;

namespace UsuarioFeedbackPlataforma.Application.Commands.UpdateFeedback
{
    public class UpdateFeedbackCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public FeedbackDto Feedback { get; set; }

        public UpdateFeedbackCommand(Guid id, FeedbackDto feedback)
        {
            Id = id;
            Feedback = feedback;
        }
    }
}
