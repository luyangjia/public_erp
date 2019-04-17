using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Security.Principal;
using System.Web.Security;
using MVC.Models;
namespace MVC.BLL
{
    public class MyPrincipal : IPrincipal
    {

        public IIdentity Identity { get; private set; }
        public UserData Account { get; set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ticket"></param>
        /// <param name="account"></param>
        public MyPrincipal(FormsAuthenticationTicket ticket, UserData account)
        {
            if (ticket == null)
                throw new ArgumentNullException("ticket");
            if (account == null)
                throw new ArgumentNullException("UserData");


            this.Identity = new FormsIdentity(ticket);
            this.Account = account;
        }
        /// <summary>
        /// 判断是否有这个角色
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public bool IsInRole(string role)
        {
            if (string.IsNullOrEmpty(role))
                return true;
            if (this.Account == null || this.Account.Roles == null)
                return false;
            return role.Split(',').Any(q => Account.Roles.Contains(q));
        }


    }
     
}
