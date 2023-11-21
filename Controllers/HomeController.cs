using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MetodyWytwarzaniaOprogramowania.Models;
using MWO.Models;

namespace MetodyWytwarzaniaOprogramowania.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }


    [HttpGet]
    public IActionResult Calculator()
    {
        OperationModel operationModel = new OperationModel();
        operationModel.Number1 = 8;
        operationModel.Number2 = 10;
        return View(operationModel);
    }

    [HttpPost]
    public IActionResult Calculator(OperationModel operation)
    {
        operation.Result = operation.Number1+operation.Number2;
        return View(operation);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
