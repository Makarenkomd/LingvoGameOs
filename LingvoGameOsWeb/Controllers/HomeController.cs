using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LingvoGameOs.Models;


namespace LingvoGameOs.Controllers;

public class HomeController : Controller
{
	public IActionResult Index()
    {

        return View();
    }

    // ������������ ������ �������������
    public string Usser()
    {
        UserViewModel user = new PlayerUserViewModel("ddkhugaev@gmail.com", "1234", "�����", "������");
        return user.ToString();
        //return View();
    }
}
