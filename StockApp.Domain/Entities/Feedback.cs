﻿namespace StockApp.Domain.Entities
{
    public class Feedback
    {
        public string UserId { get; set; }
        public string Message { get; set; }
        public string Sentiment { get; set; }
    }
}
