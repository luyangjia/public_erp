using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.BLL;
using MVC.Helper;
using MVC.Helper.Unity;
using MVC.Models;
using System.Linq.Expressions;
namespace MVC.UI.Controllers
{
    // 假期相关控制器
    public class LeaveController : Controller
    {
        private IT_LeaveSettingBLL it_LeaveSettingBLL;
        private IT_LeaveApplyBLL it_LeaveApplyBLL;
        private IT_UserBLL it_UserBLL; 
        UserData CookieData = new UserData();
        public LeaveController()
        {
            it_LeaveSettingBLL = ServiceLocator.Instance.GetService<IT_LeaveSettingBLL>();
            it_LeaveApplyBLL = ServiceLocator.Instance.GetService<IT_LeaveApplyBLL>();
            it_UserBLL = ServiceLocator.Instance.GetService<IT_UserBLL>();
            
            
        }
        #region 假期基本设置
        /// <summary>
        /// 假期基本设置
        /// </summary>
        /// <returns></returns>
        public ActionResult SettingIndex()
        {
            return View();
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public ActionResult SettingSearch(LeaveSettingModel parament)
        {
            T_LeaveSettingModel model = new T_LeaveSettingModel();
            Dictionary<string, string> orders = new Dictionary<string, string>(); //排序
            string method = Request.HttpMethod;
            if (method.Equals("POST"))
            {
                //排序
                if (!string.IsNullOrEmpty(parament.sort)) ;
                orders.Add(parament.sort, parament.order);
                //查询条件
               // model.StaffName = parament.StaffName; 
                //查询
                var data = it_LeaveSettingBLL.Search(model, orders, parament.rows, parament.page);
                return Json(data, JsonRequestBehavior.AllowGet);
            } 
            return View(); 
        }
        /// <summary>
        /// 添加，修改 删除
        /// </summary>
        /// <param name="parament"></param>
        /// <returns></returns>
        [HttpPost]
        public ContentResult SettingAction(T_LeaveSettingModel parament)
        {
            int i = 0;
            string result = "Error";
            try
            {
                switch (parament.Action)
                {
                    case "Add":
                        i = it_LeaveSettingBLL.AddData(parament);
                        break;
                    case "Edit":
                        i = it_LeaveSettingBLL.EditData(parament);
                        break;
                    case "Delete":
                        i = it_LeaveSettingBLL.DeleteData(parament);
                        break;
                    default:
                        break;

                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }

            if (i > 0)
            {
                result = "OK";
            }
            return Content(result);
        }

        public ActionResult GetSetting()
        {
            //这里按ID排序，主要是配合StaffSearch 动态列，不要轻易改变
            List<T_LeaveSettingModel> result = new List<T_LeaveSettingModel>();
            result = it_LeaveSettingBLL.Filter().OrderBy(b=>b.Id).ToList();
            return Json(result, JsonRequestBehavior.AllowGet); 
        }
        #endregion
        #region 员工假期
        /// <summary>
        /// 员工假期表
        /// </summary>
        /// <returns></returns>
        public ActionResult StaffIndex()
        {
            return View();
        }
        /// <summary>
        /// 查询,这个查询是按员工查询的，所以查询的条件只能和STAFF一样
        /// </summary>
        /// <returns></returns>
        public ActionResult StaffSearch(UserModel parament)
        {

            T_UserModel model = new T_UserModel();
            Dictionary<string, string> orders = new Dictionary<string, string>(); //排序
            string method = Request.HttpMethod;
            if (method.Equals("POST"))
            {
                //排序
                if (!string.IsNullOrEmpty(parament.sort)) ;
                orders.Add(parament.sort, parament.order);
                //查询条件
                model.StaffName = parament.StaffName;
                model.CompanyId = parament.CompanyId;
                //查询
                DataGrid<T_UserModel> data = it_UserBLL.Search(model, orders, parament.rows, parament.page);
                DataGrid<T_LeaveForUser> newdata = new DataGrid<T_LeaveForUser>();
                newdata.total = data.total;
                var rows = data.rows;
                //获得假期类型对象 
                List<T_LeaveSettingModel> Setting = new List<T_LeaveSettingModel>();
                Setting = it_LeaveSettingBLL.Filter().OrderBy(b => b.Id).ToList();
                List<int> statusids=new List<int>(){1,4,5};
                List<T_LeaveForUser> newdatarows = new List<T_LeaveForUser>();
                foreach(var item in rows)
                {
                    T_LeaveForUser leave = new T_LeaveForUser();
                    leave.CompanyName = item.CompanyName;
                    leave.StaffName = item.StaffName;
                    leave.Dateoined = item.Dateoined;

                    int i=0;
                    decimal nowdays=0;
                    decimal totaldays=0;
                    string str = "";
                    foreach(var setting in Setting )
                    {
                        str = "";
                        nowdays=it_LeaveApplyBLL.GetDays(item.Id,setting.Id,statusids,out totaldays);
                        if (nowdays >= 0 && totaldays >= 0)
                        {
                            if (nowdays == totaldays)
                            {
                                str ="<font color=#0000CC>" +nowdays.ToString() + "/" + totaldays.ToString()+"</font>"; 
                            }
                            else if (nowdays>totaldays)
                            {
                                 str ="<font color=#FF0000>0/" + totaldays.ToString()+"</font>";  
                            }
                            else
                            {
                                str = (totaldays-nowdays).ToString() + "/" + totaldays.ToString(); 
                            }
                             
                        }
                        else
                        {
                            str = "--";
                        } 
                           
                      #region 类型参数

                            if (i == 0)
                                leave.SettingValue0 = str;
                            else if (i == 1)
                                leave.SettingValue1 = str;
                            else if (i == 2)
                                leave.SettingValue2 = str;
                            else if (i == 3)
                                leave.SettingValue3 = str;
                            else if (i == 4)
                                leave.SettingValue4 = str;
                            else if (i == 5)
                                leave.SettingValue5 = str;
                            else if (i == 6)
                                leave.SettingValue6 = str;
                            else if (i == 7)
                                leave.SettingValue7 = str;
                            else if (i == 8)
                                leave.SettingValue8 = str;
                            else if (i == 9)
                                leave.SettingValue9 = str;
                            else if (i == 10)
                                leave.SettingValue10 = str;
                            else if (i == 11)
                                leave.SettingValue11 = str;
                            else if (i == 12)
                                leave.SettingValue12 = str;
                            else if (i == 13)
                                leave.SettingValue13 = str;
                            else if (i == 14)
                                leave.SettingValue14 = str;
                            else if (i == 15)
                                leave.SettingValue15 = str;
                            else if (i == 16)
                                leave.SettingValue16 = str;
                            else if (i == 17)
                                leave.SettingValue17 = str;
                            else if (i == 18)
                                leave.SettingValue18 = str;
                            else if (i == 19)
                                leave.SettingValue19 = str;
                            else if (i == 20)
                                leave.SettingValue20 = str;
                            else if (i == 21)
                                leave.SettingValue21 = str;
                            else if (i == 22)
                                leave.SettingValue22 = str;
                            else if (i == 23)
                                leave.SettingValue23 = str;
                            else if (i == 24)
                                leave.SettingValue24 = str;
                            else if (i == 25)
                                leave.SettingValue25 = str;
                            else if (i == 26)
                                leave.SettingValue26 = str;
                            else if (i == 27)
                                leave.SettingValue27 = str;
                            else if (i == 28)
                                leave.SettingValue28 = str;
                            else if (i == 29)
                                leave.SettingValue29 = str;
                         
                        #endregion  
                      i=i+1;
                    }
                    newdatarows.Add(leave);

                }
                newdata.rows = newdatarows;
                return Json(newdata, JsonRequestBehavior.AllowGet);
            }
            return View();
            

        }
        /// <summary>
        /// 添加，修改 删除
        /// </summary>
        /// <param name="parament"></param>
        /// <returns></returns>
        [HttpPost]
        public ContentResult StaffAction(T_LeaveSettingModel parament)
        {
            int i = 0;
            string result = "Error";
            try
            {
                switch (parament.Action)
                {
                    case "Add":
                        i = it_LeaveSettingBLL.AddData(parament);
                        break;
                    case "Edit":
                        i = it_LeaveSettingBLL.EditData(parament);
                        break;
                    case "Delete":
                        i = it_LeaveSettingBLL.DeleteData(parament);
                        break;
                    default:
                        break;

                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }

            if (i > 0)
            {
                result = "OK";
            }
            return Content(result);
        }

        #endregion
        #region 员工假期申请列表
        /// <summary>
        /// 员工假期申请列表,只要是显示自己的假期请假情况和操作
        /// </summary>
        /// <returns></returns>
        public ActionResult ApplyIndex()
        {
            var CookieUser = HttpContext.User as MyPrincipal;
            if (CookieUser != null)
                CookieData = CookieUser.Account;

            ViewBag.UserId = CookieData.UserId;
            ViewBag.UserName = CookieData.UserName; 
            return View();
        }
        /// <summary>
        /// 查询,这个查询是按员工查询的，所以查询的条件只能和STAFF一样
        /// </summary>
        /// <returns></returns> 
        public ActionResult ApplySearch(LeaveApplyModel parament)
        {
            int userId = -1;
            var CookieUser = HttpContext.User as MyPrincipal;
            if (CookieUser != null)
            {
                CookieData = CookieUser.Account;
                userId = CookieData.UserId;
            } 
            T_LeaveApplyModel model = new T_LeaveApplyModel();
            Dictionary<string, string> orders = new Dictionary<string, string>(); //排序
            string method = Request.HttpMethod;
            if (method.Equals("POST"))
            {
                //排序
                if (!string.IsNullOrEmpty(parament.sort)) ;
                orders.Add(parament.sort, parament.order);
                //查询条件
                //model.UserName = parament.UserName;
                //model.SetingId = parament.SetingId; 
                model.FromDate = parament.BeginTime;
                model.EndDate = parament.EndTime;
                model.UserId = userId;
                //查询
                var data = it_LeaveApplyBLL.Search(model, orders, parament.rows, parament.page);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            return View();

        }
        /// <summary>
        /// 添加，修改 删除
        /// </summary>
        /// <param name="parament"></param>
        /// <returns></returns>
        [HttpPost]
        public ContentResult ApplyAction(T_LeaveApplyModel parament)
        {
            var CookieUser = HttpContext.User as MyPrincipal;
            if (CookieUser != null)
                CookieData = CookieUser.Account;
            int i = 0;
            string result = "Error";
            try
            {
                switch (parament.Action)
                {
                    case "Apply":
                        //申请 
                        parament.CreateUserId = CookieData.UserId;
                        parament.CreateUser = CookieData.UserName;
                        parament.CreateDate = DateTime.Now;
                        parament.UserId = CookieData.UserId;
                        parament.UserName = CookieData.UserName;
                        i = it_LeaveApplyBLL.AddData(parament);
                        break;
                    case "Undo": 
                        //默认0未审批；1通过，2拒绝， 3变更申请中，5销假申请中，10作废
                        parament.IsLock = 0;
                        parament.StatusList = new List<int>() {1,3,5 };
                        i = it_LeaveApplyBLL.UndoApply(parament);
                        break;
                    case "Delete":
                        parament.IsLock = 0;
                        parament.StatusList = new List<int>() {0,10 };
                        i = it_LeaveApplyBLL.DeleteApply(parament);
                        break;
                    case "Change":
                        parament.CreateUserId = CookieData.UserId;
                        parament.CreateUser = CookieData.UserName;
                        parament.CreateDate = DateTime.Now;
                        parament.UserId = CookieData.UserId;
                        parament.UserName = CookieData.UserName;
                        parament.IsLock = 0; //当查询条件
                        parament.StatusList = new List<int>() {1};
                        i = it_LeaveApplyBLL.ChangeApply(parament);
                        break;
                    default:
                        break;

                }
            }
            catch (Exception ex)
            {
                result = ex.Message.ToString();
            }
            finally
            {
            }

            if (i > 0)
            {
                result = "OK";
            }
            return Content(result);
        }

        #endregion
        #region 员工假期审批列表
        /// <summary>
        /// 只显示自己下面的成员的请假条，不包括自己(暂时不做权限)
        /// </summary>
        /// <returns></returns>
        public ActionResult ApprovalIndex()
        {
            var CookieUser = HttpContext.User as MyPrincipal;
            if (CookieUser != null)
                CookieData = CookieUser.Account;

            ViewBag.UserId = CookieData.UserId;
            ViewBag.UserName = CookieData.UserName;
            return View();
        }
        /// <summary>
        /// 查询,状态是0，3，5
        /// </summary>
        /// <returns></returns> 
        public ActionResult ApprovalSearch(LeaveApplyModel parament)
        {
            int userId = -1;
            var CookieUser = HttpContext.User as MyPrincipal;
            if (CookieUser != null)
            {
                CookieData = CookieUser.Account;
                userId = CookieData.UserId;
            }
            T_LeaveApplyModel model = new T_LeaveApplyModel();
            Dictionary<string, string> orders = new Dictionary<string, string>(); //排序
            string method = Request.HttpMethod;
            if (method.Equals("POST"))
            {
                //排序
                if (!string.IsNullOrEmpty(parament.sort)) ;
                orders.Add(parament.sort, parament.order);
                //查询条件 
                model.FromDate = parament.BeginTime;
                model.EndDate = parament.EndTime;
                model.StatusList = new List<int>() { 0,3,5};
                //查询
                var data = it_LeaveApplyBLL.Search(model, orders, parament.rows, parament.page);
                //计算每种假期剩下多少天，总共多少天
                List<T_LeaveApplyModel> rows = data.rows;
                List<int> status=new List<int>(){1,4,5};
                foreach (var item in rows)
                {
                   decimal totalday=0;
                   decimal days=0;
                   days=it_LeaveApplyBLL.GetDays(item.UserId,item.SetingId,status,out totalday);
                    item.UseDays=days;
                    item.TotalDays=totalday;

                }
                data.rows=rows;
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            return View();

        }
        /// <summary>
        /// 添加，修改 删除
        /// </summary>
        /// <param name="parament"></param>
        /// <returns></returns>
        [HttpPost]
        public ContentResult ApprovalAction(T_LeaveApplyModel parament)
        {
            var CookieUser = HttpContext.User as MyPrincipal;
            if (CookieUser != null)
                CookieData = CookieUser.Account;
            int i = 0;
            string result = "Error";
            try
            {
                switch (parament.Action)
                {
                    case "Approval":
                        //申请 
                        parament.ApprovalId = CookieData.UserId;
                        parament.ApprovalName = CookieData.UserName;
                        i = it_LeaveApplyBLL.ApprovalData(parament);
                        break; 
                    default:
                        break;

                }
            }
            catch (Exception ex)
            {
                result = ex.Message.ToString();
            }
            finally
            {
            }

            if (i > 0)
            {
                result = "OK";
            }
            return Content(result);
        }

        #endregion

        #region 假期列表，主要是为了管理员添加假期，不需要审核
        /// <summary>
        /// 假期列表
        /// </summary>
        /// <returns></returns>
        public ActionResult ListIndex()
        { 
            return View();
        }
        /// <summary>
        /// 查询,这个查询是按员工查询的，所以查询的条件只能和STAFF一样
        /// </summary>
        /// <returns></returns>
        public ActionResult ListSearch(LeaveApplyModel parament)
        {
            T_LeaveApplyModel model = new T_LeaveApplyModel();
            Dictionary<string, string> orders = new Dictionary<string, string>(); //排序
            string method = Request.HttpMethod;
            if (method.Equals("POST"))
            {
                //排序
                if (!string.IsNullOrEmpty(parament.sort)) ;
                orders.Add(parament.sort, parament.order);
                //查询条件
                model.UserName = parament.UserName;
                model.SetingId = parament.SetingId;
                model.StatusList=new List<int>(){1,2};
                //查询
                var data = it_LeaveApplyBLL.Search(model, orders, parament.rows, parament.page);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            return View();

        }
        /// <summary>
        /// 添加，修改 删除，给管理员增加和删除假期
        /// </summary>
        /// <param name="parament"></param>
        /// <returns></returns>
        [HttpPost]
        public ContentResult ListAction(T_LeaveApplyModel parament)
        {
            var CookieUser = HttpContext.User as MyPrincipal;
            if (CookieUser != null)
                CookieData = CookieUser.Account;
            int i = 0;
            string result = "Error";
            try
            {
                switch (parament.Action)
                {
                    case "Add":
                        parament.ApprovalId = CookieData.UserId;
                        parament.ApprovalName = CookieData.UserName;
                        parament.CreateUserId = CookieData.UserId;
                        parament.CreateUser = CookieData.UserName;
                        parament.CreateDate = DateTime.Now;
                        i = it_LeaveApplyBLL.AddData(parament);
                        break;
                    case "Edit":
                         parament.ApprovalId = CookieData.UserId;
                        parament.ApprovalName = CookieData.UserName;
                        parament.CreateUserId = CookieData.UserId;
                        parament.CreateUser = CookieData.UserName;
                        parament.CreateDate = DateTime.Now;
                        i = it_LeaveApplyBLL.EditData(parament);
                        break;
                    case "Delete":
                        i = it_LeaveApplyBLL.DeleteData(parament);
                        break;
                    default:
                        break;

                }
            }
            catch (Exception ex)
            {
                result = ex.Message.ToString();
            }
            finally
            {
            }

            if (i > 0)
            {
                result = "OK";
            }
            return Content(result);
        }

        #endregion

    }
}