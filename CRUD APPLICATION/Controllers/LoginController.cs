//using CRUD_APPLICATION.JWT_Files;
//using CRUD_APPLICATION.Models;
using CRUD_APPLICATION.JWT_Files;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CRUD_APPLICATION.Controllers
{
    public class LoginController : Controller
    {
        DataContexts db = new DataContexts();
        // GET: Login

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(Logins lo)
        {
            bool a = db.UserLogins(lo);
            if (a)
            {
                return RedirectToAction("Index", "Category");
            }
            return View();
        }


        public ActionResult Log()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Log(Logins lo, string ReturnUrl)
        {
            var logs = db.Logins.FirstOrDefault(model => model.UserName == lo.UserName && model.Password == lo.Password);
            //if(logs != null) 
            //{
            //    FormsAuthentication.SetAuthCookie(lo.UserName, false);
            //    if (Url.IsLocalUrl(ReturnUrl) && ReturnUrl.Length > 1 && ReturnUrl.StartsWith("/"))
            //    {
            //        return Redirect(ReturnUrl);
            //    }
            //        return RedirectToAction("Index", "Category");
            //}

            var token = jwtHelper.JwtTokenCreate(lo);
            Response.Cookies.Set(new HttpCookie("Bearer", token));
            return RedirectToAction("Index", "Category");
        }


        public ActionResult Logout()
        {
            var cookie = Request.Cookies["Bearer"];
            cookie.Expires = DateTime.Now.AddMinutes(2);
            Response.Cookies.Add(cookie);
            return RedirectToAction("Log");
        }


        public ActionResult Error()
        {
            return View();
        }
    }
}