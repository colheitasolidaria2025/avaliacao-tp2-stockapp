using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Application.Services
{
	public interface IBackupService
	{
		void BackupDatabase();
	}

	public class BackupService : IBackupService
	{
		private readonly string _backupPath;
		private readonly ILogger<BackupService> _logger;

		public BackupService(IConfiguration configuration, ILogger<BackupService> logger)
		{
			_backupPath = configuration["BackupPath"];
			_logger = logger;
		}

		public void BackupDatabase()
		{
			try
			{
				var backupFile = Path.Combine(_backupPath, $"backup_{DateTime.Now:yyyyMMddHHmmss}.bak");

				// Exemplo: Faz uma cópia simples do arquivo do banco (para SQLite)
				// Para SQL Server você usaria um comando SQL de backup
				var dbPath = "App_Data/yourdatabase.db";  // ajuste o caminho do seu banco
				File.Copy(dbPath, backupFile, overwrite: true);

				_logger.LogInformation("Backup realizado com sucesso em {BackupFile}", backupFile);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Erro ao realizar o backup do banco de dados.");
			}
		}
	}
}
