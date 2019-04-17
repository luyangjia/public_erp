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
    public class SystemController : Controller
    {
        private IT_UserBLL it_UserBLL;
        private IT_TreeBLL it_TreeBLL;
        private IT_CompanyBLL it_CompanyBLL;
        private IT_SysBLL it_SysBLL;
        private IT_SysListBLL it_SysListBLL;
        private IT_LogBLL it_LogBLL;
        private IT_RoleBLL it_RoleBLL;
        private IT_DepartmentBLL it_DepartmentBLL; 
        public SystemController()
        {
            it_UserBLL = ServiceLocator.Instance.GetService<IT_UserBLL>();
            it_TreeBLL = ServiceLocator.Instance.GetService<IT_TreeBLL>();
            it_CompanyBLL = ServiceLocator.Instance.GetService<IT_CompanyBLL>();
            it_SysBLL = ServiceLocator.Instance.GetService<IT_SysBLL>();
            it_SysListBLL = ServiceLocator.Instance.GetService<IT_SysListBLL>();
            it_LogBLL = ServiceLocator.Instance.GetService<IT_LogBLL>();
            it_RoleBLL = ServiceLocator.Instance.GetService<IT_RoleBLL>();
            it_DepartmentBLL = ServiceLocator.Instance.GetService<IT_DepartmentBLL>(); 
        }
        // GET: System
        public ActionResult Index()
        {
            return View();
        }

        #region 菜单管理

        /// <summary>
        /// 菜单管理
        /// </summary>
        /// <returns></returns>
        public ActionResult MenuIndex()
        {
            return View();
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public ActionResult MenuSearch()
        {  
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            string enable=Request["enable"];  //1表示过滤enable=true的，空是全部
             if(enable=="1")
             {
                 dictionary.Add("Enable", "true");
             }
            var data = it_TreeBLL.Tree(dictionary);
            return Json(data, JsonRequestBehavior.AllowGet);

        }
    /// <summary>
        /// 添加，修改 删除
    /// </summary>
    /// <param name="parament"></param>
    /// <returns></returns>
        [HttpPost]
        public ContentResult MenuAction(T_TreeModel parament)
        {
            int i = 0;
            string result = "Error";
            try
            {
                switch (parament.Action)
                {
                    case "Add":
                        i = it_TreeBLL.AddData(parament);
                        break;
                    case "Edit":
                        i = it_TreeBLL.EditData(parament);
                        break;
                    case "Delete":
                        i = it_TreeBLL.DeleteData(parament);
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
        public ActionResult GetParent()
        { 
            string method = Request.HttpMethod;
            //if (method.Equals("GET"))
            //{
            //    return View();
            //}
            //else if (method.Equals("POST"))
            var data = it_TreeBLL.TreeParent();
            return   Json(data, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 用户管理

        /// <summary>
        /// 用户管理
        /// </summary>
        /// <returns></returns>
        public ActionResult StaffIndex()
        {
            return View();
        }
        /// <summary>
        /// 查询用户信息
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
        public ContentResult StaffAction(T_UserModel parament)
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

        #region 角色管理

        /// <summary>
        /// 角色管理
        /// </summary>
        /// <returns></returns>
        public ActionResult RoleIndex()
        {
            return View();
        }
        /// <summary>
        /// 获取角色
        /// </summary>
        /// <returns></returns>
        public ActionResult GetRole()
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            string method = Request.HttpMethod;
            if (method.Equals("POST"))
            {
                var data = it_RoleBLL.Filter();
                DataGrid<T_RoleModel> result = new DataGrid<T_RoleModel>() { 
                 rows=data,
                 total=data.Count()
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            return View();
        }
        /// <summary>
        /// 添加，修改 删除
        /// </summary>
        /// <param name="parament"></param>
        /// <returns></returns>
        [HttpPost]
        public ContentResult RoleAction(T_RoleModel parament)
        {
            int i = 0;
            string result = "Error";
            try
            {
                switch (parament.Action)
                {
                    case "Add":
                        i = it_RoleBLL.AddData(parament);
                        break;
                    case "Edit":
                        i = it_RoleBLL.EditData(parament);
                        break;
                    case "Delete":
                        i = it_RoleBLL.DeleteData(parament);
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
        #region 公司管理

        /// <summary>
        /// 角色管理
        /// </summary>
        /// <returns></returns>
        public ActionResult CompanyIndex()
        {
            return View();
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public ActionResult CompanySearch(CompanyModel parament)
        {
            T_CompanyModel model = new T_CompanyModel();
            Dictionary<string, string> orders = new Dictionary<string, string>(); //排序
            string method = Request.HttpMethod;
            if (method.Equals("POST"))
            {
                 //排序
                if (!string.IsNullOrEmpty(parament.sort)) ;
                  orders.Add(parament.sort, parament.order);
                //查询条件
                  model.Company = parament.Company; 
                //查询 
                  var data = it_CompanyBLL.Search(model, orders, parament.rows, parament.page);
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
        public ContentResult CompanyAction(T_CompanyModel parament)
        {
            int i = 0;
            string result = "Error";
            try
            {
                switch (parament.Action)
                {
                    case "Add":
                        i = it_CompanyBLL.AddData(parament);
                        break;
                    case "Edit":
                        i = it_CompanyBLL.EditData(parament);
                        break;
                    case "Delete":
                        i = it_CompanyBLL.DeleteData(parament);
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
        #region 部门管理

         
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public ActionResult DepartmentSearch(DepartmentModel parament)
        {
            T_DepartmentModel model = new T_DepartmentModel();
            Dictionary<string, string> orders = new Dictionary<string, string>(); //排序 
            string method = Request.HttpMethod;
            if (method.Equals("POST"))
            {
                //排序
                if (!string.IsNullOrEmpty(parament.sort)) ;
                orders.Add(parament.sort, parament.order);
                //查询条件
              //  model.company = parament.company;
                //查询  
                var data = it_DepartmentBLL.Search(model, orders, parament.rows, parament.page);
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
        public ContentResult DepartmentAction(T_DepartmentModel parament)
        {
            int i = 0;
            string result = "Error";
            try
            {
                switch (parament.Action)
                {
                    case "Add":
                        i = it_DepartmentBLL.AddData(parament);
                        break;
                    case "Edit":
                        i = it_DepartmentBLL.EditData(parament);
                        break;
                    case "Delete":
                        i = it_DepartmentBLL.DeleteData(parament);
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
        #region 参数管理

        /// <summary>
        /// 参数管理
        /// </summary>
        /// <returns></returns>
        public ActionResult ParameterIndex()
        {
            return View();
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public ActionResult GetSys()
        {
             
            string method = Request.HttpMethod;
            if (method.Equals("POST"))
            {
                var data = it_SysBLL.Filter();
                DataGrid<T_SysModel> result = new DataGrid<T_SysModel>()
                {
                     rows=data,
                    total=data.Count()
                };
                return Json(result, JsonRequestBehavior.AllowGet); 
            }
            return View();  
        }
        public ActionResult GetSysList()
        {
            List<T_TreeSysListModel> result = new List<T_TreeSysListModel>();
            Dictionary<string, object> dictionary = new Dictionary<string, object>(); 
            int SysId = Request["SysId"] == null ? 0 : int.Parse(Request["SysId"]);
            string method = Request.HttpMethod;
            string first = Request["first"];
            if (first == "null")
            {
                result.Add(new T_TreeSysListModel { id = "", text = "　" });
            }

            if (method.Equals("POST"))
            {
                var data = it_SysListBLL.Tree(SysId);
                result.AddRange(data);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            return View();
        }
        /// <summary>
        /// 添加，修改 删除
        /// </summary>
        /// <param name="parament"></param>
        /// <returns></returns>
        [HttpPost]
        public ContentResult SysListAction(T_SysListModel parament)
        {
            int i = 0;
            string result = "Error";
            try
            {
                switch (parament.Action)
                {
                    case "Add":
                        i = it_SysListBLL.AddData(parament);
                        break;
                    case "Edit":
                        i = it_SysListBLL.EditData(parament);
                        break;
                    case "Delete":
                        i = it_SysListBLL.DeleteData(parament);
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
        public ActionResult GetSysListParent()
        {
            string method = Request.HttpMethod;
            int SysId = Request["SId"] == null ? 0 : int.Parse(Request["SId"]); 
            var data = it_SysListBLL.TreeCombox(SysId); 
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region 日志管理

        /// <summary>
        /// 日志管理
        /// </summary>
        /// <returns></returns>
        public ActionResult LogIndex()
        {
            return View();
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public ActionResult LogSearch(LogModel parament)
        {
            T_LogModel model = new T_LogModel();
            Dictionary<string, string> orders = new Dictionary<string, string>(); //排序  
            string method = Request.HttpMethod;
            if (method.Equals("POST"))
            {
                //排序
                if (!string.IsNullOrEmpty(parament.sort)) ;
                orders.Add(parament.sort, parament.order);
                //查询条件
                model.BeginTime = parament.BeginTime;
                model.EndTime = parament.EndTime;
                //查询 
                var data = it_LogBLL.Search(model, orders, parament.rows, parament.page);
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
        public ContentResult LogDelete(string deleteID)
        {
            int i = 0;
            string result = "Error";
            try
            {
              if(!string.IsNullOrEmpty(deleteID))
              {
                  var ids = deleteID.Split(',');
                  foreach (var id in ids)
                  {
                      T_LogModel log = new T_LogModel();
                      log.Id = int.Parse(id);
                      i =i+ it_LogBLL.DeleteData(log);
                  }
              }
                // 
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
     
    }
}