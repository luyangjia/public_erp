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
    public class AssetController : Controller
    {
        private IT_UserBLL it_UserBLL; 
        private IT_CompanyBLL it_CompanyBLL; 
        private IT_SysListBLL it_SysListBLL; 
        private IT_DepartmentBLL it_DepartmentBLL;
        private IT_FixedAssetsBLL it_FixedAssetsBLL;
        UserData CookieData = new UserData();
        public AssetController()
        {
            it_UserBLL = ServiceLocator.Instance.GetService<IT_UserBLL>(); 
            it_CompanyBLL = ServiceLocator.Instance.GetService<IT_CompanyBLL>(); 
            it_SysListBLL = ServiceLocator.Instance.GetService<IT_SysListBLL>(); 
            it_DepartmentBLL = ServiceLocator.Instance.GetService<IT_DepartmentBLL>();
            it_FixedAssetsBLL = ServiceLocator.Instance.GetService<IT_FixedAssetsBLL>(); 
        }

        // GET: 固定资产
        #region 资产列表
        /// <summary>
        /// 资产主页
        /// </summary>
        /// <returns></returns>
        public ActionResult AssetIndex()
        {
            return View();
        } 
        /// <summary>
        /// 查询用户信息
        /// </summary>
        /// <returns></returns>
        public ActionResult AssetSearch(FixedAssetsModel parament)
        {
            T_FixedAssetsModel model = new T_FixedAssetsModel();
            Dictionary<string, string> orders = new Dictionary<string, string>(); //排序
            string method = Request.HttpMethod;
            if (method.Equals("POST"))
            {
                //排序
                if (!string.IsNullOrEmpty(parament.sort)) ;
                orders.Add(parament.sort, parament.order);
                //查询条件
                model.AssetsNo = parament.AssetsNo;
                model.BeginTime = parament.BeginTime;
                model.EndTime = parament.EndTime;
                model.Category = parament.Category;
                model.Name = parament.Name;
                model.CompanyId = parament.CompanyId;
                if (parament.Status != null)
                { 
                    List<int> st = new List<int>() { (int)parament.Status };
                    model.StatusList = st;
                }
                else
                {
                    model.StatusList = new List<int>() { 0, 1, 2 }; 
                }

                //查询
                var data = it_FixedAssetsBLL.Search(model, orders, parament.rows, parament.page);
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
        public ContentResult AssetAction(T_FixedAssetsModel parament)
        {
            
            int i = 0;
            string result = "Error";
            try
            {
                var CookieUser = HttpContext.User as MyPrincipal;
                if (CookieUser != null)
                    CookieData = CookieUser.Account;

                switch (parament.Action)
                {
                    case "Add":
                      //  parament.Status = 0;
                        parament.CreateUserId = CookieData.UserId;
                        parament.CreateUserName = CookieData.UserName;
                        parament.CreateDate = DateTime.Now;
                        i = it_FixedAssetsBLL.AddData(parament);
                        break;
                    case "Edit":
                        parament.CreateUserId = CookieData.UserId;
                        parament.CreateUserName = CookieData.UserName;
                        parament.CreateDate = DateTime.Now;
                        EditFixedAssetsModel newmodel = new EditFixedAssetsModel();
                        newmodel = (EditFixedAssetsModel)Helper.Method.CopyModel(parament, newmodel); 
                        i = it_FixedAssetsBLL.EditData(newmodel.Id, newmodel);
                        break;
                    case "Delete":
                        i = it_FixedAssetsBLL.DeleteData(parament);
                        break;
                    default:
                        break;

                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
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

        public ActionResult AssetRecord()
        {
            return View();
        }

        #endregion

        #region 资产报损
        public ActionResult ScrapIndex()
        {
            return View();
        }
        /// <summary>
        /// 查询用户信息
        /// </summary>
        /// <returns></returns>
        public ActionResult ScrapSearch(UserModel parament)
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
                var data = it_UserBLL.Search(model, orders, parament.rows, parament.page);
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
        public ContentResult ScrapAction(T_UserModel parament)
        {
            int i = 0;
            string result = "Error";
            try
            {
                switch (parament.Action)
                {
                    case "Add":
                        parament.Password = Helper.Encrypt.Encrypto(parament.Password);
                        i = it_UserBLL.AddData(parament);
                        break;
                    case "Edit":
                        T_UserStaffModel newmodel = new T_UserStaffModel();
                        parament.Password = Helper.Encrypt.Encrypto(parament.Password);
                        newmodel = (T_UserStaffModel)Helper.Method.CopyModel(parament, newmodel);
                        i = it_UserBLL.EditData(newmodel.Id, newmodel);
                        break;
                    case "Delete":
                        i = it_UserBLL.DeleteData(parament);
                        break;
                    default:
                        break;

                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
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

        #region 资产出售
        public ActionResult SellIndex()
        {
            return View();
        }
        /// <summary>
        /// 查询用户信息
        /// </summary>
        /// <returns></returns>
        public ActionResult SellSearch(UserModel parament)
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
                var data = it_UserBLL.Search(model, orders, parament.rows, parament.page);
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
        public ContentResult SellAction(T_UserModel parament)
        {
            int i = 0;
            string result = "Error";
            try
            {
                switch (parament.Action)
                {
                    case "Add":
                        parament.Password = Helper.Encrypt.Encrypto(parament.Password);
                        i = it_UserBLL.AddData(parament);
                        break;
                    case "Edit":
                        T_UserStaffModel newmodel = new T_UserStaffModel();
                        parament.Password = Helper.Encrypt.Encrypto(parament.Password);
                        newmodel = (T_UserStaffModel)Helper.Method.CopyModel(parament, newmodel);
                        i = it_UserBLL.EditData(newmodel.Id, newmodel);
                        break;
                    case "Delete":
                        i = it_UserBLL.DeleteData(parament);
                        break;
                    default:
                        break;

                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
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