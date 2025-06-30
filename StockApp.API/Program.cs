using StockApp.Application.Interfaces;
using StockApp.Application.Services;
using StockApp.Domain.Interfaces;
using StockApp.Infra.Data.Repositories;
using StockApp.Infra.IoC;

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

        builder.Services.AddScoped<IReviewRepository, ReviewRepository>();

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


        builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
        var backupService = app.Services.GetRequiredService<IBackupService>();
        var timer = new System.Threading.Timer(_ => backupService.BackupDatabase(), null, TimeSpan.Zero, TimeSpan.FromHours(24));



    }
}