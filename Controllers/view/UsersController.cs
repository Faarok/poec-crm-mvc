using Microsoft.AspNetCore.Mvc;

namespace Crm;
public class UsersController : Controller
{

    public IActionResult Index()
    {
        ViewBag.Title = "Users";
        return View(RepoTools.UserApi.Get());
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        User User = RepoTools.UserApi.Get(id);
        ViewBag.Title = "Details of " + User.FirstName + " " + User.LastName;
        return View(User);
    }

    public IActionResult BuisnessUnit(string BuisnessUnit)
    {
        foreach(User user in RepoTools.UserApi.Get())
        {
            if(user.BuisnessUnit == BuisnessUnit)
            {
                return View(user);
            }
        }

        throw new Exception("This buisness unit doesn't exist.");
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        User User = RepoTools.UserApi.Get(id);
        ViewBag.Title = "Editing " + User.FirstName + " " + User.LastName;
        return View(User);
    }

    [HttpPost]
    public IActionResult Edit(User updatedUser)
    {
        RepoTools.UserApi.Put(updatedUser.ID, updatedUser);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        RepoTools.UserApi.Delete(id);
        return RedirectToAction("Index");
    }

    public IActionResult Create()
    {
        ViewBag.Title = "Add User";
        return View();
    }

    [HttpPost]
    public IActionResult Create(User newUser)
    {
        RepoTools.UserApi.Post(newUser);
        return RedirectToAction("Index");
    }
}