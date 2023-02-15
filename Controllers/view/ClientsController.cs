using Microsoft.AspNetCore.Mvc;

namespace Crm;
public class ClientsController : Controller
{

    private ClientApiController ClientApi = new();

    public IActionResult Index()
    {
        ViewBag.Title = "Clients";
        return View(ClientApi.Get());
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        Client client = ClientApi.Get(id);
        ViewBag.Title = "Details of " + client.Name;
        return View(client);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        Client client = ClientApi.Get(id);
        ViewBag.Title = "Editing " + client.Name;
        return View(client);
    }

    [HttpPost]
    public IActionResult Edit(Client updatedClient)
    {
        ClientApi.Put(updatedClient.ID, updatedClient);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        ClientApi.Delete(id);
        return RedirectToAction("Index");
    }

    public IActionResult Create()
    {
        ViewBag.Title = "Add client";
        return View();
    }

    [HttpPost]
    public IActionResult Create(Client newClient)
    {
        ClientApi.Post(newClient);
        return RedirectToAction("Index");
    }
}