using MediatR;
using MyMediateR.Models;

namespace MyMediateR.Commands.Products;

public record AddProductCommand(Product Product) : IRequest<Product>;
