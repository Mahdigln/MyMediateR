using MediatR;
using MyMediateR.Models;

namespace MyMediateR.Commands.Products;

public record UpdateProductCommand(int id, Product product) : IRequest<Product>;
