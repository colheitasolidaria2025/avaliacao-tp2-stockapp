using Microsoft.AspNetCore.Mvc;
using StockApp.Domain.Entities;
using StockApp.Domain.Interfaces;

namespace StockApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase

    {
        [HttpPost("{id}/upload-image")]
        public async Task<IActionResult> UploadImage(int id, IFormFile image)
        {
            if (image == null || image.Length == 0)
            {
                return BadRequest("Imagem inválida");
            }
            var directory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var fileExtension = Path.GetExtension(image.FileName);
            var filePath = Path.Combine(directory, $"{id}{fileExtension}");

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }
            return Ok(new { message = "Imagem enviada com sucesso!", path = $"/images/{id}{fileExtension}" });
        }
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            var products = await _productRepository.GetProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            var product = await _productRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);

        }
<<<<<<< Updated upstream
    }
=======
		[HttpGet("filtered")]
		public async Task<ActionResult<IEnumerable<Product>>> GetFiltered(
	     [FromQuery] string name,
	    [FromQuery] decimal? minPrice,
	    [FromQuery] decimal? maxPrice)
		{
			var products = await _productRepository.GetFilteredAsync(name, minPrice, maxPrice);
			return Ok(products);
		}
		private readonly IReviewRepository _reviewRepository;

		public ProductsController(IReviewRepository reviewRepository /*, outros parâmetros que você já tem */)
		{
			_reviewRepository = reviewRepository;
			// atribua outros parâmetros
		}

		[HttpPost("{productId}/review")]
		public async Task<IActionResult> AddReview(int productId, [FromBody] Review review)
		{
			if (review.Rating < 1 || review.Rating > 5)
			{
				return BadRequest("Rating deve ser entre 1 e 5.");
			}

			review.ProductId = productId;
			review.Date = DateTime.Now;

			await _reviewRepository.AddAsync(review);
			return Ok();
		}

		[HttpGet("{productId}/reviews")]
		public async Task<IActionResult> GetReviews(int productId)
		{
			var reviews = await _reviewRepository.GetByProductIdAsync(productId);
			return Ok(reviews);
		}


	}
>>>>>>> Stashed changes
}
