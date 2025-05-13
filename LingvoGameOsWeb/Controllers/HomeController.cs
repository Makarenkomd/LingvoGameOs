using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LingvoGameOs.Models;
using LingvoGameOs.Db;


namespace LingvoGameOs.Controllers;

public class HomeController : Controller
{
    readonly IGamesRepository gamesRepository;
    readonly NewDatabaseContext newDatabaseContext;

    public HomeController(IGamesRepository gamesRepository, NewDatabaseContext newDatabaseContext)
    {
        this.gamesRepository = gamesRepository;
        this.newDatabaseContext = newDatabaseContext;
    }

    public IActionResult Index()
    {
        var games = gamesRepository.GetAll();
        ViewBag.GameTypes = newDatabaseContext.GameTypes.Select(type => type.Name);
        return View(games);
    }

    // ������������ ������ �������������
    public string Usser()
    {
        UserViewModel user = new PlayerUserViewModel("ddkhugaev@gmail.com", "1234", "�����", "������");
        return user.ToString();
        //return View();
    }
}
