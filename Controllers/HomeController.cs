using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LingvoGameOs.Models;
using LingvoGameOs.data;
using LingvoGameOs.data.Models;

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
        User user = new PlayerUser("ddkhugaev@gmail.com", "1234", "�����", "������");
        return user.ToString();
        //return View();
    }
}
