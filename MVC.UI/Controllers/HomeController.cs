using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.BLL;
using MVC.Helper;
using MVC.Helper.Unity;
using MVC.Models;
using System.Net.Sockets;
using System.Net;
using System.Security.Principal;
using System.Web.Security;
using System.Web.Script.Serialization;
using System.Linq.Expressions;
namespace MVC.UI.Controllers
{
    public class HomeController : Controller
    {
        private IT_UserBLL it_UserBLL;
        private IT_TreeBLL it_Treebll;
        private IT_LogBLL  it_LogBLL; 
        public HomeController()
        {
            it_UserBLL = ServiceLocator.Instance.GetService<IT_UserBLL>();
            it_Treebll = ServiceLocator.Instance.GetService<IT_TreeBLL>();
            it_LogBLL = ServiceLocator.Instance.GetService<IT_LogBLL>(); 
        }

        // GET: Home
      
        public ActionResult Index()
        {
            return View();
        } 

        #region 左侧菜单
       // [Authorize]
        public ActionResult GetMenu()
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("Enable", true);
            var data = it_Treebll.Tree(dictionary);
            return Json(data, JsonRequestBehavior.AllowGet);
            
        }

        #endregion

        #region 登录
        
        public ActionResult Login()
        {

            return View();
        }
        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="loginmodel"></param>
        /// <returns></returns>
        public ActionResult LoginAction(LoginModel loginmodel)
        {
            LoginModel result = new LoginModel();
            T_LogModel logmodel = new T_LogModel();
            string status = "failed";
            try
            {
                result = it_UserBLL.LoginUser(loginmodel);
                if (result != null)
                {
                    status = "success";
                    　string hostName = Dns.GetHostName();   //获取本机名
　                  　IPHostEntry localhost = Dns.GetHostByName(hostName);    //方法已过期，可以获取IPv4的地址
　　                    //IPHostEntry localhost = Dns.GetHostEntry(hostName);   //获取IPv6地址
　　                     IPAddress localaddr = localhost.AddressList[0];

                       UserData user = new UserData()
                       {
                           UserId = result.Id,
                           UserName = result.UserName,
                           RoleId = result.RoleId,
                           CompanyId = result.CompanyId,
                           Roles = result.Roles,
                          // Roles = new string[] { "aaa", "bbb", "cc", "dd" },
                       };
                       // 1. 把需要保存的用户数据转成一个字符串。 
                       string data = null;
                       if (user != null)
                           data = (new JavaScriptSerializer()).Serialize(user);  
                       FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                               1,
                               user.UserName,
                               DateTime.Now,
                               DateTime.Now.Add(FormsAuthentication.Timeout),
                              true,
                               data
                               ); 
                       //加密Cookie
                       HttpCookie cookie = new HttpCookie(
                           FormsAuthentication.FormsCookieName,
                           FormsAuthentication.Encrypt(ticket)); 
                       Response.Cookies.Add(cookie); 
                    //写日志
                    logmodel.CreateTime = DateTime.Now;
                    logmodel.Ip = localaddr.ToString();
                    logmodel.LoginId = result.LoginId;
                    logmodel.StaffName = result.UserName;
                    logmodel.Types = "login";
                    it_LogBLL.AddData(logmodel);
                    //

                }

            }
            catch(Exception ex) {
                status = ex.Message;
            }
            finally { }

            return Json(status, JsonRequestBehavior.AllowGet);
        }
      /// <summary>
      /// 注销
      /// </summary>
      /// <returns></returns>
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region 登录测试
        
        [Authorize(Users = "admin", Roles = "cc")]
        //[Authorize(Users="admin", Roles = "admin")]
        //[Authorize(Roles = "employee,manager")]
        public ContentResult Logincenter()
        {

            return Content("ok");
            

        }
    
        public ContentResult Logincenter2()
        {
            bool b1 = HttpContext.User.Identity.IsAuthenticated;
            var a = HttpContext.User.Identity;
            var b = a.Name;
            var c = a.IsAuthenticated;
            var d = HttpContext.User.IsInRole("aaa");
            var user = HttpContext.User as MyPrincipal;
            UserData datas = user.Account;
            
            return Content("ok");


        }
        public ActionResult Login2()
        {
         
            
            UserData user=new UserData(){
             UserId=11,
             UserName = "admin",
               RoleId=1,
                CompanyId=1,
                 CompanyName="hg",
                  Roles= new string[] {"aaa","bbb","cc","dd" }, 
            };
             // 1. 把需要保存的用户数据转成一个字符串。 
            string data = null;
            if (user!=null)
              data = (new JavaScriptSerializer()).Serialize(user);
              
           //  string userJson = JsonConvert.SerializeObject(user);

          FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                  1,
                  user.UserName,
                  DateTime.Now,
                  DateTime.Now.Add(FormsAuthentication.Timeout),
                 true,
                  data
                  );           
               

             HttpCookie cookie = new HttpCookie(  
                 FormsAuthentication.FormsCookieName,
                 FormsAuthentication.Encrypt(ticket)); 

             Response.Cookies.Add(cookie);
              
             return Content("ok");
        }
        

        #endregion

    }
}