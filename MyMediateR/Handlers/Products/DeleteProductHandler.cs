using MediatR;
using MyMediateR.Commands.Products;
using MyMediateR.Contracts;
using MyMediateR.Models;

namespace MyMediateR.Handlers.Products;

public class DeleteProductHandler : IRequestHandler<DeleteProductCommand,bool>
{
    private IProductRepository _productRepository;

    public DeleteProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async  Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.Find(request.id);
        if (product == null)
            return false;
         await _productRepository.Remove(request.id);
         return true;
    }
}