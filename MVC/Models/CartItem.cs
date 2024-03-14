namespace MVC.Models;

public class CartItem
{
    public int Id { get; set; }
    public Car Car { get; set; }
    public int Price { get; set; }
    public string CartId { get; set; }
}
