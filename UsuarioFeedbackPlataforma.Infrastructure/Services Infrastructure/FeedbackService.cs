using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioFeedbackPlataforma.Core.Entities;
using UsuarioFeedbackPlataforma.Core.Services_Domain;
using UsuarioFeedbackPlataforma.Infrastructure.Repository;

namespace UsuarioFeedbackPlataforma.Infrastructure.Services_Infrastructure
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbackService(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        public async Task<IEnumerable<Feedback>> GetAllFeedbackAsync()
        {
            var feedback = await _feedbackRepository.GetAllFeedbackAsync();

            if (feedback == null || !feedback.Any())
            {
                throw new Exception("Nenhum feedback foi encontrado.");
            }

            return feedback;
        }

        public async Task<Feedback> GetByIdFeedbackAsync(Guid id)
        {
            var feedback = await _feedbackRepository.GetByIdFeedbackAsync(id);

            if (feedback == null)
            {
                throw new Exception($"Nenhum feedback com este {id} foi encontrado");
            }

            return feedback;
        }

        public async Task<Feedback> AddAsync(Feedback feedback)
        {
            if (feedback == null)
            {
                throw new ArgumentNullException(nameof(feedback), "Feedback não pode ser nulo.");
            }

            return await _feedbackRepository.AddAsync(feedback);
        }

        public async Task<Feedback> UpdateAsync(Guid id, Feedback feedback)
        {
            var feedbackExisting = await _feedbackRepository.GetByIdFeedbackAsync(id);

            if (feedbackExisting == null)
            {
                throw new Exception($"Nenhum feedback com este {id} foi encontrado");
            }

            feedbackExisting.UserName = feedback.UserName;
            feedbackExisting.Message = feedback.Message;

            return await _feedbackRepository.UpdateAsync(id, feedback);
        }

        public async Task<Feedback> DeleteAsync(Guid id)
        {
            var feedbackExisting = await _feedbackRepository.GetByIdFeedbackAsync(id);

            if (feedbackExisting == null)
            {
                throw new Exception($"Nenhum feedback com este {id} foi encontrado");
            }

            return await _feedbackRepository.DeleteAsync(id);
        }
    }
}
