using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioFeedbackPlataforma.Core.Entities;
using UsuarioFeedbackPlataforma.Infrastructure.Data;

namespace UsuarioFeedbackPlataforma.Infrastructure.Repository
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly FeedbackDbContext _context;

        public FeedbackRepository(FeedbackDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Feedback>> GetAllFeedbackAsync()
        {
            return await _context.Feedbacks.ToListAsync();
        }

        public async Task<Feedback> GetByIdFeedbackAsync(Guid id)
        {
            var feedback = await _context.Feedbacks.FindAsync(id);

            if (feedback == null)
            {
                throw new Exception($"Nenhum feedback com este {id} foi encontrado");
            }

            return feedback;
        }

        public async Task<Feedback> AddAsync(Feedback feedback)
        {
            await _context.Feedbacks.AddAsync(feedback);
            await _context.SaveChangesAsync();

            if (feedback == null)
            {
                throw new ArgumentNullException(nameof(feedback), "Feedback não pode ser null");
            }

            return feedback;
        }

        public async Task<Feedback> UpdateAsync(Guid id, Feedback feedback)
        {
            var feedbackExisting = await _context.Feedbacks.FindAsync(id);

            if (feedbackExisting == null)
            {
                throw new Exception($"Nenhum feedback com este {id} foi encontrado");
            }

            feedbackExisting.UserName = feedback.UserName;
            feedbackExisting.Message = feedback.Message;

            await _context.SaveChangesAsync();

            return feedbackExisting;
        }

        public async Task<Feedback> DeleteAsync(Guid id)
        {
            var feedback = await _context.Feedbacks.FindAsync(id);

            if (feedback == null)
            {
                throw new Exception($"Nenhum feedback com este {id} foi encontrado");
            }

            _context.Feedbacks.Remove(feedback);
            await _context.SaveChangesAsync();

            return feedback;
        }
    }
}
