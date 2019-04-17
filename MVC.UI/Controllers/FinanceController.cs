using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Expressions;
namespace MVC.UI.Controllers
{
    public class FinanceController : Controller
    {
        // GET: Finance 财务管理
        #region  员工基本工资
        public ActionResult StaffSalaryIndex()
        {
            return View();
        }

        #endregion

        #region  项目分红
        public ActionResult CommissionIndex()
        {
            return View();
        }
        #endregion
    }
}