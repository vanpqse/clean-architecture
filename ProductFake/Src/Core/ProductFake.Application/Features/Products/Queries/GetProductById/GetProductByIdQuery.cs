using MediatR;
using ProductFake.Application.Wrappers;
using ProductFake.Domain.Products.Dtos;

namespace ProductFake.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<BaseResult<ProductDto>>
    {
        public long Id { get; set; }
    }
}
