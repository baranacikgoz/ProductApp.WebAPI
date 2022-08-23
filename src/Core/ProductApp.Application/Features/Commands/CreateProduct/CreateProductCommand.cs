using AutoMapper;
using MediatR;
using ProductApp.Application.Interfaces.Repositories;
using ProductApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProductApp.Application.Features.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<ServiceResponse<Guid>>
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public int Quantity { get; set; }


        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ServiceResponse<Guid>>
        {
            private readonly IProductRepositoryAsync _productRepository;
            private readonly IMapper _mapper;

            public CreateProductCommandHandler(IProductRepositoryAsync productRepository, IMapper mapper)
            {
                _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
                _mapper = mapper;
            }

            public async Task<ServiceResponse<Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                var product = _mapper.Map<Domain.Entities.Product>(request);
                await _productRepository.AddAsync(product);

                return new ServiceResponse<Guid>(product.Id) { IsSuccess = true };
            }
        }
    }
}
