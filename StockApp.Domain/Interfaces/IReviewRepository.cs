using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockApp.Domain.Entities;
using System.Threading.Tasks;


namespace StockApp.Domain.Interfaces
{
	public interface IReviewRepository
	{
		Task AddAsync(Review review);
		Task<IEnumerable<Review>> GetByProductIdAsync(int productId);
	}

}
