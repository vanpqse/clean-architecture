﻿using MediatR;
using ProductFake.Application.Helpers;
using ProductFake.Application.Interfaces;
using ProductFake.Application.Interfaces.Repositories;
using ProductFake.Application.Wrappers;
using ProductFake.Domain.Products.Dtos;
using System.Threading;
using System.Threading.Tasks;

namespace ProductFake.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQueryHandler(IProductRepository productRepository, ITranslator translator) : IRequestHandler<GetProductByIdQuery, BaseResult<ProductDto>>
    {
        public async Task<BaseResult<ProductDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetByIdAsync(request.Id);

            if (product is null)
            {
                return new BaseResult<ProductDto>(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.ProductMessages.Product_notfound_with_id(request.Id)), nameof(request.Id)));
            }

            var result = new ProductDto(product);

            return new BaseResult<ProductDto>(result);
        }
    }
}
