using MediatR;
using ProductFake.Application.Wrappers;

namespace ProductFake.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<BaseResult>
    {
        public long Id { get; set; }
    }
}
