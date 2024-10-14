using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuarioFeedbackPlataforma.Core.Entities
{
    public class Feedback
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }


        public Feedback(Guid id, string userName, string message, DateTime createdAt)
        {
            Id = id;
            UserName = userName;
            Message = message;
            CreatedAt = createdAt;
        }
    }
}
