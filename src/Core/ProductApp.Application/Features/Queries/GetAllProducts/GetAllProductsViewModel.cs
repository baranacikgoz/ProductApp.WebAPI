using System;
using System.Collections.Generic;
using System.Text;

namespace ProductApp.Application.Features.Queries.GetAllProducts
{
    public class GetAllProductsViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
