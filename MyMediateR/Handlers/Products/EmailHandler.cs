using MediatR;
using MyMediateR.Contracts;
using MyMediateR.Notifications.Products;

namespace MyMediateR.Handlers.Products;

public class EmailHandler : INotificationHandler<ProductAddedNotification>
{
    //private IProductRepository _productRepository;
    private ILogger<EmailHandler> _logger;

    public EmailHandler(ILogger<EmailHandler> logger)
    {
        _logger = logger;
    }
    public async Task Handle(ProductAddedNotification notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("email sent");
        await Task.CompletedTask;
    }
}