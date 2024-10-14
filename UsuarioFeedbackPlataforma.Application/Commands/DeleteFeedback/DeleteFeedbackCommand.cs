using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuarioFeedbackPlataforma.Application.Commands.DeleteFeedback
{
    public class DeleteFeedbackCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }

        public DeleteFeedbackCommand(Guid id)
        {
            Id = id;
        }
    }
}
