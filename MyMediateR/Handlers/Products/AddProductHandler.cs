using MediatR;
using MyMediateR.Commands.Products;
using MyMediateR.Contracts;
using MyMediateR.Models;
using MyMediateR.Notifications.Products;

namespace MyMediateR.Handlers.Products;

public class AddProductHandler:IRequestHandler<AddProductCommand,Product>
{
    private IProductRepository _productRepository;
    private IMediator _mediator;
    public AddProductHandler(IProductRepository productRepository, IMediator mediator)
    {
        _productRepository = productRepository;
        _mediator = mediator;
    }
    
    public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
       var result= await _productRepository.Add(request.Product);
      await _mediator.Publish(new ProductAddedNotification(result) {Product = result}, cancellationToken);
        return result;
    }
}