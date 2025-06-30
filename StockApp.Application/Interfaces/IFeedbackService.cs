using StockApp.Domain.Entities;

namespace StockApp.Application.Interfaces
{
    public interface IFeedbackService
    {
        Task SubmitFeedbackAsync(string userId, string message);
        List<Feedback> GetAllFeedbacks();
    }
}
