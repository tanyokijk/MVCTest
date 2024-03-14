using Microsoft.AspNetCore.Mvc;
using MVC.Interfaces;
using MVC.Models;

namespace MVC.Controllers;

public class OrderController : Controller
{
    private readonly IAllOrders allOrders;
    private readonly ShopCart shopCart;

    public OrderController(IAllOrders allOrders, ShopCart shopCart)
    {
        this.allOrders = allOrders;
        this.shopCart = shopCart;
    }

    public IActionResult Checkout()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Checkout(Order order)
    {
        shopCart.ListShopItems = shopCart.GetShopItems();

        if (shopCart.ListShopItems.Count == 0)
        {
            ModelState.AddModelError("", "У вас мають бути товари!");
        }

        if (ModelState.IsValid)
        {
            allOrders.createOrder(order);
            return RedirectToAction("Complete");
        }

        return RedirectToAction("Complete");
        //return View(order);
    }

    public IActionResult Complete()
    {
        ViewBag.Message = "Замовлення успішно оброблено";
        return View();
    }


}
