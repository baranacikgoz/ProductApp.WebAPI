using MediatR;
using ProductApp.Application.Dto;
using ProductApp.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProductApp.Application.Features.Queries.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<List<ProductViewDto>>
    {
        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductViewDto>>
        {
            private readonly IProductRepositoryAsync _productRepository;

            public GetAllProductsQueryHandler(IProductRepositoryAsync productRepository)
            {
                _productRepository = productRepository;
            }

            public async Task<List<ProductViewDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
            {
                var products = await _productRepository.GetAllAsync();
            }
        }
    }
}
