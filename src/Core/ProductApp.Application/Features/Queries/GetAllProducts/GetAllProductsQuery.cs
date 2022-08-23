using AutoMapper;
using MediatR;
using ProductApp.Application.Dto;
using ProductApp.Application.Interfaces.Repositories;
using ProductApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProductApp.Application.Features.Queries.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<ServiceResponse<List<ProductViewDto>>>
    {
        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, ServiceResponse<List<ProductViewDto>>>
        {
            private readonly IProductRepositoryAsync _productRepository;
            private readonly IMapper _mapper;

            public GetAllProductsQueryHandler(IProductRepositoryAsync productRepository, IMapper mapper)
            {
                _productRepository = productRepository;
                _mapper = mapper;
            }

            public async Task<ServiceResponse<List<ProductViewDto>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
            {
                var products = await _productRepository.GetAllAsync();

                var viewModel = _mapper.Map<List<ProductViewDto>>(products);

                //var viewModel = products.Select(i => new ProductViewDto()
                //{
                //    Id = i.Id,
                //    Name = i.Name,
                //}).ToList();

                return new ServiceResponse<List<ProductViewDto>>(viewModel) { IsSuccess = true };
            }
        }
    }
}
