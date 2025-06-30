using StockApp.Application.Interfaces;
using StockApp.Application.Services;
using StockApp.Infra.IoC;
using StockApp.Domain;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddInfrastructureAPI(builder.Configuration);

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddSingleton<ICartService, CartService>();
        builder.Services.AddSingleton<ISentimentAnalysisService, SentimentAnalysisService>();
        builder.Services.AddSingleton<IFeedbackService, FeedbackService>();
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();


		if (app.Environment.IsDevelopment())
		{
			app.UseDeveloperExceptionPage();
		}


		app.UseRouting();
		app.UseAuthentication();
		app.UseAuthorization();

		app.MapControllers();

		app.Run();


	}
}