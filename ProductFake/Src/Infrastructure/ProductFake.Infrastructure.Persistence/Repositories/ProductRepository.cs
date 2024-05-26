using Microsoft.EntityFrameworkCore;
using ProductFake.Application.DTOs;
using ProductFake.Application.Interfaces.Repositories;
using ProductFake.Domain.Products.Dtos;
using ProductFake.Domain.Products.Entities;
using ProductFake.Infrastructure.Persistence.Contexts;
using System.Linq;
using System.Threading.Tasks;

namespace ProductFake.Infrastructure.Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly DbSet<Product> products;

        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            products = dbContext.Set<Product>();

        }

        public async Task<PagenationResponseDto<ProductDto>> GetPagedListAsync(int pageNumber, int pageSize, string name)
        {
            var query = products.OrderBy(p => p.Created).AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(p => p.Name.Contains(name));
            }

            return await Paged(
                query.Select(p => new ProductDto(p)),
                pageNumber,
                pageSize);

        }
    }
}
