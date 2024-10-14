using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioFeedbackPlataforma.Core.Entities;

namespace UsuarioFeedbackPlataforma.Infrastructure.Repository
{
    public interface IFeedbackRepository
    {
        Task<IEnumerable<Feedback>> GetAllFeedbackAsync();
        Task<Feedback> GetByIdFeedbackAsync(Guid id);
        Task<Feedback> AddAsync(Feedback feedback);
        Task<Feedback> UpdateAsync(Guid id, Feedback feedback);
        Task<Feedback> DeleteAsync(Guid id);
    }
}
