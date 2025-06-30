namespace StockApp.Application.Services
{
  public class SentimentAnalysisService : ISentimentAnalysisService
    {
        public string AnalyzeSentiment(string message)
        {
            message = message.ToLower();
            if (message.Contains("ótimo") || message.Contains("bom"))
                return "Positivo";
            else if (message.Contains("ruim") || message.Contains("péssimo"))
                return "Negativo";
            else
                return "Neutro";
            

            
        }
    }

    public interface ISentimentAnalysisService
    {
        string AnalyzeSentiment(string message);
    }
}