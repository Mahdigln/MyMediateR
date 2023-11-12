using MediatR;
using MyMediateR.Commands.Products;
using MyMediateR.Contracts;
using MyMediateR.Models;

namespace MyMediateR.Handlers.Products;

public class UpdateProductHandler:IRequestHandler<UpdateProductCommand,Product>
{
    private IProductRepository _productRepository;

    public UpdateProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
       return await _productRepository.Update(request.product);
    }
}