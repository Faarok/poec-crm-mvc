using Microsoft.AspNetCore.Mvc;

namespace Crm;
public class OrdersController : Controller
{

    private OrderApiController OrderApi = new();

    public IActionResult Index()
    {
        ViewBag.Title = "Orders";
        return View(OrderApi.Get());
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        Order Order = OrderApi.Get(id);
        ViewBag.Title = "Details of " + Order.TypePresta + " " + Order.ID;
        return View(Order);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        Order Order = OrderApi.Get(id);
        ViewBag.Title = "Editing " + Order.TypePresta + " " + Order.ID;
        return View(Order);
    }

    [HttpPost]
    public IActionResult Edit(Order updatedOrder)
    {
        OrderApi.Put(updatedOrder.ID, updatedOrder);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        OrderApi.Delete(id);
        return RedirectToAction("Index");
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Order newOrder)
    {
        OrderApi.Post(newOrder);
        return RedirectToAction("Index");
    }
}