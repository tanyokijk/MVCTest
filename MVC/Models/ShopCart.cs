using Microsoft.EntityFrameworkCore;

namespace MVC.Models;

public class ShopCart
{
    private readonly AppDBContext appDBContext;

    public ShopCart(AppDBContext appDBContext)
    {
        this.appDBContext = appDBContext;
    }
    public string ShopCartId { get; set; }
    public List<CartItem> ListShopItems { get; set; }

    public static ShopCart GetCart(IServiceProvider services)
    {
        ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
        var context = services.GetService<AppDBContext>();
        string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

        session.SetString("CartId", shopCartId);

        return new ShopCart(context) { ShopCartId = shopCartId };
    }

    public void AddToCart(Car car)
    {
        appDBContext.CartItem.Add(new CartItem
        {
            CartId = ShopCartId,
            Car = car,
            Price = car.Price
        });

        appDBContext.SaveChanges();
    }

    public void RemoveFromCart(Car car)
    {
        var cartItem = appDBContext.CartItem.FirstOrDefault(item => item.CartId == ShopCartId && item.Car.Id == car.Id);

        if (cartItem != null)
        {
            appDBContext.CartItem.Remove(cartItem);
            appDBContext.SaveChanges();
        }
    }

    public List<CartItem> GetShopItems()
    {
        return appDBContext.CartItem.Where(c => c.CartId == ShopCartId).Include(s => s.Car).ToList();
    }
}
