using Microsoft.AspNetCore.Mvc;
namespace DemoMvc.Controllers
{
    public class NguyenKhanhLinhTestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string name, string address)
        {
            string message = $"Tên của bạn là: {name}, Địa chi ở: {address} nhé";
            ViewBag.Message = message;
            return View();
        }
    }
}