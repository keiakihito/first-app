using Microsoft.AspNetCore.Mvc;
using MinApp.Models;

namespace MinApp.Controllers;

public class UserController : Controller
{
    private static List<User> _users = new();  // No DB for demo

    [HttpGet]
    public IActionResult Index()
    {
        return View(_users);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(User user)
    {
        if (ModelState.IsValid)
        {
            _users.Add(user);
            return RedirectToAction("Index");
        }
        return View(user);
    }
}