using MediatR;
using MyMediateR.Models;

namespace MyMediateR.Queries.Products;

public record GetProductByIdQuery(int Id) : IRequest<Product>;
