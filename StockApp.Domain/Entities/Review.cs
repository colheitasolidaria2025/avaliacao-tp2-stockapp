using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Domain.Entities
{
	public class Review
	{
		public int Id { get; set; }
		public int ProductId { get; set; }
		public string UserId { get; set; }
		public int Rating { get; set; }  // Ex: 1 a 5
		public string Comment { get; set; }
		public DateTime Date { get; set; }

		// Relação (opcional)
		public Product Product { get; set; }
	}

}
