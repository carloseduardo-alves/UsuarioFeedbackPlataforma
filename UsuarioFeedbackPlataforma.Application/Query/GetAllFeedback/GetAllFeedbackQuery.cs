using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioFeedbackPlataforma.Application.Dto;

namespace UsuarioFeedbackPlataforma.Application.Query.GetAllFeedback
{
    public class GetAllFeedbackQuery : IRequest<IEnumerable<FeedbackDto>>
    {

    }
}
