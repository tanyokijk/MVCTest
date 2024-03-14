namespace MVC.Models;

public class Car
{
    public int Id { get; set; }
    public Category Category { get; set; }
    public string? Slug { get; set; }
    public string Image { get; set; } = "/img/standart.png";
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public bool IsFavourite { get; set; } = true;
    public bool Available { get; set; } = true;
    public int StockQuantity { get; set; } = 0;
}
