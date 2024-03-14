using MVC.Interfaces;
using MVC.Models;

namespace MVC.Repository;

public class OrdersRepository : IAllOrders
{
    private readonly AppDBContext appDBContext;
    private readonly ShopCart shopCart;

    public OrdersRepository(AppDBContext appDBContext, ShopCart shopCart)
    {
        this.appDBContext = appDBContext;
        this.shopCart = shopCart;
    }

    public void createOrder(Order order)
    {
        order.OrderTime = DateTime.Now;
        appDBContext.Order.Add(order);

        var items = shopCart.ListShopItems;

        foreach (var el in items)
        {
            var orderDetail = new OrderDetail()
            {
                CarId = el.Car.Id,
                OrderId = order.Id,
                Price = el.Car.Price,
            };
            appDBContext.OrderDetail.Add(orderDetail);
        }
        appDBContext.SaveChanges();
    }
}
