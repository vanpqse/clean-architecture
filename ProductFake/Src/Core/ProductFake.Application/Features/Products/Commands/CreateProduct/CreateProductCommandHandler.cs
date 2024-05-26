using MediatR;
using ProductFake.Application.Interfaces;
using ProductFake.Application.Interfaces.Repositories;
using ProductFake.Application.Wrappers;
using ProductFake.Domain.Products.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace ProductFake.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateProductCommand, BaseResult<long>>
    {
        public async Task<BaseResult<long>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(request.Name, request.Price, request.BarCode);

            await productRepository.AddAsync(product);
            await unitOfWork.SaveChangesAsync();

            return new BaseResult<long>(product.Id);
        }
    }
}
