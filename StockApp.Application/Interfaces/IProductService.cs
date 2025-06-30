﻿using StockApp.Application.DTOs;

namespace StockApp.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProducts();
        Task<ProductDTO> GetProductById(int? id);
        Task Add(ProductDTO productDto);
        Task Update(ProductDTO productDto);
        Task Remove(int? id);

        Task BulkUpdateAsync(List<ProductDTO> products);

    }
}
