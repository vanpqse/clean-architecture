using ProductFake.Application.DTOs;
using ProductFake.Domain.Products.Dtos;
using ProductFake.Domain.Products.Entities;
using System.Threading.Tasks;

namespace ProductFake.Application.Interfaces.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<PagenationResponseDto<ProductDto>> GetPagedListAsync(int pageNumber, int pageSize, string name);
    }
}
