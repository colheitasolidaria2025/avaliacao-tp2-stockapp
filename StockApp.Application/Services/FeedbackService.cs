using StockApp.Application.Interfaces;
using StockApp.Domain.Entities;

namespace StockApp.Application.Services
{
    public class FeedbackService: IFeedbackService
    {
        private readonly ISentimentAnalysisService _sentimentService;
        private readonly List<Feedback> _feedbacks = new();

        public FeedbackService(ISentimentAnalysisService sentimentService)
        {
            _sentimentService = sentimentService;
        }

        public async Task SubmitFeedbackAsync(string userId, string message)
        {
            var sentiment = _sentimentService.AnalyzeSentiment(message);
            var feedback = new Feedback
            {
                UserId = userId,
                Message = message,
                Sentiment = sentiment

            };

            _feedbacks.Add(feedback);
            await Task.CompletedTask;
        }

        public List<Feedback> GetAllFeedbacks() => _feedbacks;
    }
}
