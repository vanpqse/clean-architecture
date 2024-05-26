using MediatR;
using ProductFake.Application.Parameters;
using ProductFake.Application.Wrappers;
using ProductFake.Domain.Products.Dtos;

namespace ProductFake.Application.Features.Products.Queries.GetPagedListProduct
{
    public class GetPagedListProductQuery : PagenationRequestParameter, IRequest<PagedResponse<ProductDto>>
    {
        public string Name { get; set; }
    }
}
