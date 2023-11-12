using MediatR;
using MyMediateR.Models;

namespace MyMediateR.Queries;
public record GetProductsQuery() : IRequest<IEnumerable<Product>>;