using MediatR;
using MyMediateR.Contracts;
using MyMediateR.Models;
using MyMediateR.Queries.Products;

namespace MyMediateR.Handlers.Products;
public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
{
    private IProductRepository _productRepository;

    public GetProductByIdHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
      return  await _productRepository.Find(request.Id);
    }
}