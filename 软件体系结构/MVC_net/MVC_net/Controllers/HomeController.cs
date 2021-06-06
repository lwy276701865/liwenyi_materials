using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_net.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()//以get方法请求 执行Index方法
        {
            return View();//Inde.cshtml视图文件经过后台渲染后放回浏览器 进行呈现
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login()//以get方法调用登陆页面
        {
            ViewBag.LoginSate = "登陆前...";
            return View();//向浏览器返回渲染后的Login.cshtml视图
        }
    }
}