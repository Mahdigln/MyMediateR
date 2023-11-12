using MediatR;
using Microsoft.EntityFrameworkCore;
using MyMediateR.Context;
using MyMediateR.Contracts;
using MyMediateR.Models;
using MyMediateR.Queries;

namespace MyMediateR.Handlers.Products;
public class GetProductsHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
{
    private IProductRepository _productRepository;

    public GetProductsHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }


    public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
      return  await _productRepository.GetAllProducts();
    }
}