using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductFake.Application.Features.Products.Commands.CreateProduct;
using ProductFake.Application.Features.Products.Commands.DeleteProduct;
using ProductFake.Application.Features.Products.Commands.UpdateProduct;
using ProductFake.Application.Features.Products.Queries.GetPagedListProduct;
using ProductFake.Application.Features.Products.Queries.GetProductById;
using ProductFake.Application.Wrappers;
using ProductFake.Domain.Products.Dtos;
using System.Threading.Tasks;

namespace ProductFake.WebApi.Controllers.v1
{
    [ApiVersion("1")]
    public class ProductController : BaseApiController
    {

        [HttpGet]
        public async Task<PagedResponse<ProductDto>> GetPagedListProduct([FromQuery] GetPagedListProductQuery model)
            => await Mediator.Send(model);

        [HttpGet]
        public async Task<BaseResult<ProductDto>> GetProductById([FromQuery] GetProductByIdQuery model)
            => await Mediator.Send(model);

        [HttpPost, Authorize]
        public async Task<BaseResult<long>> CreateProduct(CreateProductCommand model)
            => await Mediator.Send(model);

        [HttpPut, Authorize]
        public async Task<BaseResult> UpdateProduct(UpdateProductCommand model)
            => await Mediator.Send(model);

        [HttpDelete, Authorize]
        public async Task<BaseResult> DeleteProduct([FromQuery] DeleteProductCommand model)
            => await Mediator.Send(model);

        [HttpDelete, Authorize]
        public async Task<BaseResult> DeleteProducts([FromQuery] DeleteProductCommand model)
            => await Mediator.Send(model);

        [HttpPost, Authorize]
        public async Task<BaseResult> CreateProducts(CreateProductCommand model)
            => await Mediator.Send(model);

        [HttpGet, Authorize]
        public async Task<BaseResult<ProductDto>> GetProductByIds([FromQuery] GetProductByIdQuery model)
            => await Mediator.Send(model);
    }
}