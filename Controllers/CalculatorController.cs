using Microsoft.AspNetCore.Mvc;
using MWO.Models;

namespace MWO.Controllers
{
    public class CalcaultorController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            OperationModel operationModel = new OperationModel();
            operationModel.Number1 = 8;
            operationModel.Number2 = 10;
            return View(operationModel);
        }

        [HttpPost]
        public IActionResult Index(OperationModel operation)
        {
            operation.Result = operation.Number1+operation.Number2;
            return View(operation);
        }
    }
}