using MediatR;
using MyMediateR.Models;

namespace MyMediateR.Commands.Products;

public record DeleteProductCommand(int id) : IRequest<bool>;
