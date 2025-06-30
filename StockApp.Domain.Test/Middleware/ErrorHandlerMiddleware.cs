using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Net;


namespace StockApp.Domain.Middleware
{
	public class ErrorHandlerMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILogger<ErrorHandlerMiddleware> _logger;
		private readonly IHostEnvironment _env;
		private static string result;

		public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger, IHostEnvironment env)
		{
			_next = next;
			_logger = logger;
			_env = env;
		}

		public async Task Invoke(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Erro: {Message} | Caminho: {Path}", ex.Message, context.Request.Path);
				await HandleExceptionAsync(context, ex, _env);
			}
		}

		private static Task HandleExceptionAsync(HttpContext context, Exception exception, IHostEnvironment env)
		{
			var code = HttpStatusCode.InternalServerError;

			if (exception is UnauthorizedAccessException)
				code = HttpStatusCode.Unauthorized;
			else if (exception is ArgumentException)
				code = HttpStatusCode.BadRequest;
			else if (exception is KeyNotFoundException)
				code = HttpStatusCode.NotFound;

			context.Response.ContentType = "application/json";
			context.Response.StatusCode = (int)code;
			return context.Response.WriteAsync(result);
		}
	}
	public static class ErrorHandlerMiddlewareExtensions
	{
		public static IApplicationBuilder UseErrorHandlerMiddleware(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<ErrorHandlerMiddleware>();
		}
	}

}
