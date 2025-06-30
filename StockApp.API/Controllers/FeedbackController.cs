using Microsoft.AspNetCore.Mvc;
using StockApp.Application.Interfaces;

namespace StockApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeedbackController: ControllerBase 
    {
        private IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpPost]
        public async Task<IActionResult> Submit([FromQuery] string userId, [FromBody] string message)
        {
            await _feedbackService.SubmitFeedbackAsync(userId, message);
            return Ok("Feedback enviado com sucesso");
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var feedbacks = _feedbackService.GetAllFeedbacks(); 
            return Ok(feedbacks);
        }
    }
}
