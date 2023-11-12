using System.ComponentModel.DataAnnotations;

namespace MyMediateR.Models;

public class Category
{
   
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public int ProductId { get; set; }


    public Product Product { get; set; }
}