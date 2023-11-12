using MediatR;
using MyMediateR.Models;

namespace MyMediateR.Notifications.Products;

public record ProductAddedNotification(Product Product) : INotification;