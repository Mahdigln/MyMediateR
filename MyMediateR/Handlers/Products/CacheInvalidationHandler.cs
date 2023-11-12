using MediatR;
using Microsoft.AspNetCore.Http.Metadata;
using MyMediateR.Contracts;
using MyMediateR.Notifications.Products;

namespace MyMediateR.Handlers.Products;

public class CacheInvalidationHandler: INotificationHandler<ProductAddedNotification>
{
    private ILogger<CacheInvalidationHandler> _logger;

    public CacheInvalidationHandler(ILogger<CacheInvalidationHandler> logger)
    {
        _logger = logger;
    }
    public async Task Handle(ProductAddedNotification notification, CancellationToken cancellationToken)
    {
       _logger.LogInformation("Cache Added");
        await Task.CompletedTask;
    }
}