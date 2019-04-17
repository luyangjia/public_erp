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
    public class DBController : Controller
    {  
       
        private IT_SupplierBLL it_SupplierBLL;
        private IT_CostBLL it_CostBLL;
        private IT_ClientBLL it_ClientBLL;
        private IT_SysListBLL it_SysListBLL;
         
        public DBController()
        {
            it_SysListBLL = ServiceLocator.Instance.GetService<IT_SysListBLL>();
            it_SupplierBLL = ServiceLocator.Instance.GetService<IT_SupplierBLL>();
            it_CostBLL = ServiceLocator.Instance.GetService<IT_CostBLL>();
            it_ClientBLL = ServiceLocator.Instance.GetService<IT_ClientBLL>();
        } 

        #region 价格管理

        /// <summary>
        /// 价格管理
        /// </summary>
        /// <returns></returns>
        public ActionResult CostIndex()
        {
            return View();
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public ActionResult CostSearch(CostModel parament)
        {
            T_CostModel model = new T_CostModel();
            Dictionary<string, string> orders = new Dictionary<string, string>(); //排序 
            string method = Request.HttpMethod;
            if (method.Equals("POST"))
            {
                //排序
                if (!string.IsNullOrEmpty(parament.sort)) ;
                orders.Add(parament.sort, parament.order);
                //查询条件
                model.Description = parament.Description;
                model.CategoryId = parament.CategoryId;
                //查询  
                var data = it_CostBLL.Search(model, orders, parament.rows, parament.page);
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
        public ContentResult CostAction(T_CostModel parament)
        {
            int i = 0;
            string result = "Error";
            try
            {
                switch (parament.Action)
                {
                    case "Add":
                        i = it_CostBLL.AddData(parament);
                        break;
                    case "Edit":
                        i = it_CostBLL.EditData(parament);
                        break;
                    case "Delete":
                        i = it_CostBLL.DeleteData(parament);
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

        #region 供应商管理 
        /// <summary>
        /// 用户管理
        /// </summary>
        /// <returns></returns>
        public ActionResult SupplierIndex()
        {
            return View();
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public ActionResult SupplierSearch(SupplierModel parament)
        {
            T_SupplierModel model = new T_SupplierModel();
            Dictionary<string, string> orders = new Dictionary<string, string>(); //排序  
            string method = Request.HttpMethod;
            if (method.Equals("POST"))
            {
                //排序
                if (!string.IsNullOrEmpty(parament.sort)) ;
                orders.Add(parament.sort, parament.order);
                //查询条件
                model.COGS = parament.COGS;
                model.CategoryId = parament.CategoryId;
                model.Company = parament.Company;
                //查询  
                var data = it_SupplierBLL.Search(model, orders, parament.rows, parament.page);
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
        public ContentResult SupplierAction(T_SupplierModel parament)
        {
            int i = 0;
            string result = "Error";
            try
            {
                switch (parament.Action)
                {
                    case "Add":
                        i = it_SupplierBLL.AddData(parament);
                        break;
                    case "Edit":
                        i = it_SupplierBLL.EditData(parament);
                        break;
                    case "Delete":
                        i = it_SupplierBLL.DeleteData(parament);
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

        #region 客户管理 
        /// <summary>
        /// 用户管理
        /// </summary>
        /// <returns></returns>
        public ActionResult ClientIndex()
        {
            return View();
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public ActionResult ClientSearch(ClientModel parament)
        {
            T_ClientModel model = new T_ClientModel();
            Dictionary<string, string> orders = new Dictionary<string, string>(); //排序  
            string method = Request.HttpMethod;
            if (method.Equals("POST"))
            {
                //排序
                if (!string.IsNullOrEmpty(parament.sort)) ;
                orders.Add(parament.sort, parament.order);
                //查询条件
                model.Name = parament.Name; 
                //查询  
                var data = it_ClientBLL.Search(model, orders, parament.rows, parament.page);
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
        public ContentResult ClientAction(T_ClientModel parament)
        {
            int i = 0;
            string result = "Error";
            try
            {
                switch (parament.Action)
                {
                    case "Add":
                        i = it_ClientBLL.AddData(parament);
                        break;
                    case "Edit":
                        i = it_ClientBLL.EditData(parament);
                        break;
                    case "Delete":
                        i = it_ClientBLL.DeleteData(parament);
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
       
      
    }
}