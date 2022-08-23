using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductApp.Application.Dto;
using ProductApp.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepositoryAsync _productRepository;

        public ProductController(IProductRepositoryAsync productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allList = await _productRepository.GetAllAsync();
            var result = allList.Select(i => new ProductViewDto()
            {
                Id = i.Id,
                Name = i.Name,
            });

            return Ok(result);
        }
    }
}
