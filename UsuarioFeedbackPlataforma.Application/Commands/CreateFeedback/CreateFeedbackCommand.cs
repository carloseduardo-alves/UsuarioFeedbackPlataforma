using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioFeedbackPlataforma.Application.Dto;

namespace UsuarioFeedbackPlataforma.Application.Commands.CreateFeedback
{
    public class CreateFeedbackCommand : IRequest<Guid>
    {
        public FeedbackDto Feedback { get; set; }

        public CreateFeedbackCommand(FeedbackDto feedback)
        {
            Feedback = feedback;
        }
    }
}
