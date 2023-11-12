using System.ComponentModel.DataAnnotations;

namespace MyMediateR.Models;

public class Product
{
  
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public double ProductPrice { get; set; }

    public List<Category> Categories { get; set; }
}