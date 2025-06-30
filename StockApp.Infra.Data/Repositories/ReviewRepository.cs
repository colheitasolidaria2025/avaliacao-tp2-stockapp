using Microsoft.EntityFrameworkCore;
using StockApp.Domain.Entities;
using StockApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockApp.Infra.Data.Context;

public class ReviewRepository : IReviewRepository
{
	private readonly DbContext _context;

	public ReviewRepository(DbContext context)
	{
		_context = context;
	}

	public async Task AddAsync(Review review)
	{
		_context.Reviews.Add(review);
		await _context.SaveChangesAsync();
	}

	public async Task<IEnumerable<Review>> GetByProductIdAsync(int productId)
	{
		return await _context.Reviews
			.Where(r => r.ProductId == productId)
			.OrderByDescending(r => r.Date)
			.ToListAsync();
	}
}
