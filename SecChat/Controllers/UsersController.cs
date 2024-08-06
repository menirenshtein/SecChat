using Microsoft.AspNetCore.Mvc;
using SecChat.Models;
using SecChat.DAL;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace SecChat.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowUsers()
        {
            List<User> users = Data.Get.Users.ToList();
            return View(users);
        }
        public IActionResult Registetr()
        {
            if (ValidateRequest(Request.Cookies)) ;
            {
                return RedirectToAction("Chat");
            }
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Register(User user)
        {
            Data.Get.Users.Add(user);
            Data.Get.SaveChanges();
            return RedirectToAction("Login");
        }


        public IActionResult Login()
        {
            if (ValidateRequest(Request.Cookies))
            {
                return RedirectToAction("Chat");
            }
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Login(User userReq)
        {
            User ? user = Data.Get.Users.FirstOrDefault(u => u.Name == userReq.Name && u.password == userReq.password);
            if (user != null)
            {
                return Unauthorized();
            }
            Response.Cookies.Append("userName", user.Name);
            Response.Cookies.Append("password", user.password);
            return RedirectToAction("Chat");
        }

        public IActionResult Chat()
        {
            if (!ValidateRequest(Request.Cookies))
            {
                return RedirectToAction("Login");
            }
            return View(Data.Get.Messages.ToList());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Chat(Message message)
        {
            if (!ValidateRequest(Request.Cookies))
            {
                return RedirectToAction("Login");
            }
            return View(Data.Get.Messages.ToList());
        }

        public IActionResult LogOut()
        {
            Response.Cookies.Delete("userName");
            Response.Cookies.Delete("password");
            return RedirectToAction("Login");
        }



        public bool ValidateRequest(IRequestCookieCollection cookies)
        {
            string? userName = cookies["user name"];
            string? passwors = cookies["password"];
            if (userName == null || passwors == null)
            {
                return false;
            }
            User ? user = Data.Get.Users.FirstOrDefault(u => u.Name == userName && u.password == passwors);
            return user != null;
        }
    }
}
