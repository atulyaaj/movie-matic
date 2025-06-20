using BookMyShowEntity;
using Microsoft.AspNetCore.Mvc;

namespace MovieCoreMvcUI.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Admin admin)
        {
            if (admin.AdminEmail == "atul@gmail.com" && admin.AdminPassword == "abc")
            {
                ViewBag.status = "Ok";
                ViewBag.message = "Admin Login successfully!";
                return RedirectToAction("Index", "Movie");
            }
            else
            {
                ViewBag.status = "Error";
                ViewBag.message = "Wrong credentials!";
            }
            return View();
        }
    }
}
