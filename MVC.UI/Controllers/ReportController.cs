using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Expressions;
namespace MVC.UI.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report 报表管理
        public ActionResult Index()
        {
            return View();
        }
        #region 项目报表
        public ActionResult ProjectDesignerIndex()
        {
            return View();
        }

        #endregion

    }
}