﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyMediateR.Commands.Products;
using MyMediateR.Contracts;
using MyMediateR.Models;
using MyMediateR.Notifications.Products;
using MyMediateR.Queries;
using MyMediateR.Queries.Products;

namespace MyMediateR.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private IProductRepository _productRepository;
    private readonly IMediator _mediator;
    private IPublisher _publisher;
    public ProductsController(IProductRepository productRepository, IMediator mediator, IPublisher publisher)
    {
        _productRepository = productRepository;
        _mediator = mediator;
        _publisher = publisher;
    }

    // GET: api/Products
    [HttpGet]
    public async Task<ActionResult> GetProducts()
    {
        var products = await _mediator.Send(new GetProductsQuery());
        return Ok(products);
    }

    // GET: api/Products/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var product = await _mediator.Send(new GetProductByIdQuery(id));
        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }

    // PUT: api/Products/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProduct(int id, Product product)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        await _productRepository.Update(product);


        return NoContent();
    }

    // POST: api/Products
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    //[HttpPost]
    //public async Task<ActionResult<Product>> PostProduct(Product product)
    //{
    //    if (!ModelState.IsValid)
    //    {
    //        return BadRequest(ModelState);
    //    }
    //    await _mediator.Send(new AddProductCommand(product));

    //    return StatusCode(201);

    //    //return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
    //}
    [HttpPost]
    public async Task<ActionResult> PostProduct([FromBody]Product product)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var productToReturn =  await _mediator.Send(new AddProductCommand(product));

        return StatusCode(201);
        
    }

    // DELETE: api/Products/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

       await _mediator.Send(new DeleteProductCommand(id));
       return Ok();

    }

    private async Task<bool> ProductExists(int id)
    {
        return await _productRepository.IsExists(id);
    }
}

