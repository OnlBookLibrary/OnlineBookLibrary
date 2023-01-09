using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineBookLibrary.Models;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Session;
using OnlineBookLibrary.Extentions;
using System.Linq.Expressions;

namespace OnlineBookLibrary.Controllers
{
    public class AccountsController : Controller
    {
        private readonly OnlineBookLibraryDataContext _context;
        public AccountsController (OnlineBookLibraryDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("UserID,UserName,Email,Password,Phone,RoleId,Address")] User user)
        {
            if (ModelState.IsValid)
            {
                if (checkEmail(user.Email) > 0)
                {
                    ModelState.AddModelError("", "Email is already exist!");
                }
                else
                {
                    var u = new User();
                    u.UserName = user.UserName;
                    u.Email = user.Email;
                    u.Password = BCrypt.Net.BCrypt.HashPassword(user.Password); /*GetMD5(user.Password + GetRandomKey());*/
                    u.Phone = user.Phone;
                    u.Address = user.Address;
                    u.RoleId= 3;

                    _context.Add(u);
                    await _context.SaveChangesAsync();
                    if (_context.Users.FirstOrDefault(i => i.Email == u.Email) != null)
                    {
                        ViewBag.Success = "Signup successfully!";
                        user = new User();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Signup Failed!");
                    }
                }
            }
            return View(user);
        }

      
        private int checkEmail(string Email)
        {

            var query = from u in _context.Users where u.Email == Email select u;

            return query.Count();
        }

        /*public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }*/
        
        /*public static int GetRandomKey()
        {
            Random ran = new Random();
            int key = ran.Next(100);
            return key;
        }*/

        // Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {
          
                
                var data = _context.Users.Where(s => s.Email.Equals(email)).ToList();
                var dataRoleId = data.FirstOrDefault().RoleId;
				bool checkPass = BCrypt.Net.BCrypt.Verify(password, data.FirstOrDefault().Password);
				if (checkPass)
                {
                    if(dataRoleId == 3) {
                        //add session
                        var User = new UserSession();
                        User.UserName = data.FirstOrDefault().UserName.ToString();
                        User.UserId = data.FirstOrDefault().UserId;
                        User.RoleId = (int)data.FirstOrDefault().RoleId;

                        HttpContext.Session.SetObjectAsJson("UserDetails", User);
                        return RedirectToAction("Index", "Home");
                    }
                    else if (dataRoleId == 1 || dataRoleId == 2)
                    {
                        //add session
                        var User = new UserSession();
                        User.UserName = data.FirstOrDefault().UserName.ToString();
                        User.UserId = data.FirstOrDefault().UserId;

                        HttpContext.Session.SetObjectAsJson("UserDetails", User);
                        return RedirectToAction("Index", "Home", new { area = "Admin"});
                    }
                    
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login", "Accounts");
                }
            }
            return View();
        }
		
		public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

    }
}
