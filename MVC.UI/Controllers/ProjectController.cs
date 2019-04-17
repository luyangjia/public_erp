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
    public class ProjectController : Controller
    {
        // GET: Project
          private IT_ProjectBLL it_ProjectBLL;
          private IT_ProjectUserBLL it_ProjectUserBLL;
          private IT_ProjectPlanBLL it_ProjectPlanBLL;
          private IT_ProjectFeeBLL it_ProjectFeeBLL;
          private IT_AgreeBLL it_AgreeBLL;
          private IT_AgreeListBLL it_AgreeListBLL;
          public ProjectController()
        { 
            
            it_ProjectBLL = ServiceLocator.Instance.GetService<IT_ProjectBLL>();
            it_ProjectUserBLL = ServiceLocator.Instance.GetService<IT_ProjectUserBLL>();
            it_ProjectPlanBLL = ServiceLocator.Instance.GetService<IT_ProjectPlanBLL>();
            it_AgreeBLL = ServiceLocator.Instance.GetService<IT_AgreeBLL>();
            it_AgreeListBLL = ServiceLocator.Instance.GetService<IT_AgreeListBLL>();
            it_ProjectFeeBLL = ServiceLocator.Instance.GetService<IT_ProjectFeeBLL>();
        } 

        #region 项目报价
        public ActionResult QuotationIndex() 
        {
            return View();
        }
        /// <summary>
        /// 查询 未开始的项目 状态0
        /// </summary>
        /// <returns></returns>
        public ActionResult QuotationSearch(ProjectModel parament)
        {
            T_ProjectModel model = new T_ProjectModel();
            Dictionary<string, string> orders = new Dictionary<string, string>(); //排序  
            string method = Request.HttpMethod;
            if (method.Equals("POST"))
            {
                //排序
                if (!string.IsNullOrEmpty(parament.sort)) ;
                orders.Add(parament.sort, parament.order);
                //查询条件 
                model.StatusList = new List<int> { 0 };
                
                //查询  
                var data = it_ProjectBLL.Search(model, orders, parament.rows, parament.page);
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
        public ContentResult QuotationAction(T_ProjectModel parament)
        {
            int i = 0;
            string result = "Error";
               
            try
            {
                switch (parament.Action)
                {
                    case "Add":
                        i = it_ProjectBLL.AddData(parament);
                        break;
                    case "Edit":
                        //i = it_ProjectBLL.EditData(parament);
                        T_ProjectEditModel newmodel = new T_ProjectEditModel(); 
                        newmodel = (T_ProjectEditModel)Helper.Method.CopyModel(parament, newmodel);
                        i = it_ProjectBLL.EditData(newmodel.Id, newmodel);
                        break;
                    case "Delete":
                        i = it_ProjectBLL.DeleteData(parament);
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


        #region 项目协议添加
        public ActionResult ProjectQuotation(string projectId) 
        {
            ViewBag.projectId = projectId;
            return View();
        }
        /// <summary>
        /// 审批中的协议只查看
        /// </summary>
        /// <returns></returns>
        public ActionResult ProjectQuotation_View(string projectId)
        {
            ViewBag.projectId = projectId;
            return View();
        }
        /// <summary>
        /// 查询  
        /// </summary>
        /// <returns></returns>
        public ActionResult ProjectQuotationSearch(AgreeModel parament)
        {
            T_AgreeModel model = new T_AgreeModel();
            Dictionary<string, string> orders = new Dictionary<string, string>(); //排序
            string method = Request.HttpMethod;
            if (method.Equals("POST"))
            {
                //排序
                if (!string.IsNullOrEmpty(parament.sort)) ;
                orders.Add(parament.sort, parament.order);
                //查询条件
                model.ProjectId = parament.ProjectId; 
                //查询
                var data = it_AgreeBLL.Search(model, orders, parament.rows, parament.page);
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
        public ContentResult ProjectQuotationAction(T_AgreeModel parament)
        {
            int i = 0;
            string result = "Error";

            try
            {
                switch (parament.Action)
                {
                    case "Add":
                        i = it_AgreeBLL.AddData(parament);
                        break;
                    case "Edit":
                        i = it_AgreeBLL.EditData(parament);
                        break;
                    case "Delete":
                        i = it_AgreeBLL.DeleteData(parament);
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
       
        public ActionResult ProjectQuotationList()
        {
            string agreeId = Request["agreeId"];
            string projectId = Request["projectId"];
            ViewBag.agreeId = agreeId;
            ViewBag.projectId = projectId; 
            return View();
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public ActionResult ProjectQuotationListSearch(AgreeList parament)
        {
            T_AgreeListModel model = new T_AgreeListModel();
            Dictionary<string, string> orders = new Dictionary<string, string>(); //排序
            string method = Request.HttpMethod;
            if (method.Equals("POST"))
            {
                //排序
                if (!string.IsNullOrEmpty(parament.sort)) ;
                orders.Add(parament.sort, parament.order);
                //查询条件
                model.AgreeId = parament.AgreeId;
                model.CategoryId = parament.CategoryId;
                //查询
                var data = it_AgreeListBLL.Search(model, orders, parament.rows, parament.page);
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
        public ContentResult ProjectQuotationListAction(T_AgreeListPost parament)
        {
            int i = 0;
            string result = "Error";

            try
            {

                switch (parament.Action)
                {
                    case "Add":
                        i = it_AgreeListBLL.AddDataList(parament.dataList);
                        break;
                    case "Edit":
                        i = it_AgreeListBLL.EditDataList(parament.dataList);
                        break;
                    case "Delete":
                        i = it_AgreeListBLL.DeleteDataList(parament.dataList);
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

        #region 项目人员管理
        public ActionResult ManageUser(string projectId)
        {
            ViewBag.projectId = projectId;
            return View();
        }
        /// <summary>
        /// 只查看
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public ActionResult ManageUser_View(string projectId)
        {
            ViewBag.projectId = projectId;
            return View();
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public ActionResult GetManage(ProjectUserModel parament)
        {
            T_ProjectUserModel model = new T_ProjectUserModel();
            Dictionary<string, string> orders = new Dictionary<string, string>(); //排序
            string method = Request.HttpMethod;
            if (method.Equals("POST"))
            {
                //排序
                if (!string.IsNullOrEmpty(parament.sort)) ;
                orders.Add(parament.sort, parament.order);
                //查询条件
                model.ProjectId = parament.ProjectId; 
                //查询
                var data = it_ProjectUserBLL.Search(model, orders, parament.rows, parament.page);
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
        public ContentResult ManageAction(T_ProjectUserModel parament)
        {
            int i = 0;
            string result = "Error";

            try
            {
                switch (parament.Action)
                {
                    case "Add":
                        i = it_ProjectUserBLL.AddData(parament);
                        break;
                    case "Edit":
                        i = it_ProjectUserBLL.EditData(parament);
                        break;
                    case "Delete":
                        i = it_ProjectUserBLL.DeleteData(parament);
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

        #region 项目计划管理
        public ActionResult ProjectPlan(string projectId)
        {
            ViewBag.projectId = projectId;
            return View();
        }
        /// <summary>
        /// 只查看
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public ActionResult ProjectPlan_View(string projectId)
        {
            ViewBag.projectId = projectId;
            return View();
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public ActionResult ProjectPlanSearch(ProjectPlanModel parament)
        {
            T_ProjectPlanModel model = new T_ProjectPlanModel();
            Dictionary<string, string> orders = new Dictionary<string, string>(); //排序
            string method = Request.HttpMethod;
            if (method.Equals("POST"))
            {
                //排序
                if (!string.IsNullOrEmpty(parament.sort)) ;
                orders.Add(parament.sort, parament.order);
                //查询条件
                model.ProjectId = parament.ProjectId;
                //查询
                var data = it_ProjectPlanBLL.Search(model, orders, parament.rows, parament.page);
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
        public ContentResult ProjectPlanAction(T_ProjectPlanModel parament)
        {
            int i = 0;
            string result = "Error";

            try
            {
                switch (parament.Action)
                {
                    case "Add":
                        i = it_ProjectPlanBLL.AddData(parament);
                        break;
                    case "Edit":
                        i = it_ProjectPlanBLL.EditData(parament);
                        break;
                    case "Delete":
                        i = it_ProjectPlanBLL.DeleteData(parament);
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

        #region 项目付款计划
        public ActionResult PaySchedule(string projectId)
        {
            ViewBag.projectId = projectId;
            return View();
        }
        /// <summary>
        /// 只查看
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public ActionResult PaySchedule_View(string projectId)
        {
            ViewBag.projectId = projectId;
            return View();
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public ActionResult PayScheduleSearch(ProjectFeeModel parament)
        {
            T_ProjectFeeModel model = new T_ProjectFeeModel();
            Dictionary<string, string> orders = new Dictionary<string, string>(); //排序
            string method = Request.HttpMethod;
            if (method.Equals("POST"))
            {
                //排序
                if (!string.IsNullOrEmpty(parament.sort)) ;
                orders.Add(parament.sort, parament.order);
                //查询条件
                model.ProjectId = parament.ProjectId;
                //查询
                var data = it_ProjectFeeBLL.Search(model, orders, parament.rows, parament.page);
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
        public ContentResult PayScheduleAction(T_ProjectFeeModel parament)
        {
            int i = 0;
            string result = "Error";

            try
            {
                switch (parament.Action)
                {
                    case "Add":
                        i = it_ProjectFeeBLL.AddData(parament);
                        break;
                    case "Edit":
                        i = it_ProjectFeeBLL.EditData(parament);
                        break;
                    case "Delete":
                        i = it_ProjectFeeBLL.DeleteData(parament);
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
        #region 项目审批 
        /// <summary>
        /// 审批主页
        /// </summary>
        /// <returns></returns>
        public ActionResult ApprovalsIndex()
        {
            return View();
        }
        /// <summary>
        /// 查询 开始的项目 状态1
        /// </summary>
        /// <returns></returns>
        public ActionResult AgreementSearch(ProjectModel parament)
        {
            T_ProjectModel model = new T_ProjectModel();
            Dictionary<string, string> orders = new Dictionary<string, string>(); //排序
            string method = Request.HttpMethod;
            if (method.Equals("POST"))
            {
                //排序
                if (!string.IsNullOrEmpty(parament.sort)) ;
                orders.Add(parament.sort, parament.order);
                //查询条件
              //  model.Description = parament.Description;
                model.StatusList = new List<int> { 1 };
                //查询
                var data = it_ProjectBLL.Search(model, orders, parament.rows, parament.page);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            return View();  


        }
        /// <summary>
        /// 符合审批项目的协议，这里只要拿出已经审批和待审批和不同意的
        /// </summary>
        /// <returns></returns>
        public ActionResult ApprovalsProjectSearch(AgreeModel parament)
        {
            T_AgreeModel model = new T_AgreeModel();
            Dictionary<string, string> orders = new Dictionary<string, string>(); //排序
            string method = Request.HttpMethod;
            if (method.Equals("POST"))
            {
                //排序
                if (!string.IsNullOrEmpty(parament.sort)) ;
                orders.Add(parament.sort, parament.order);
                //查询条件 
                model.ProjectId = parament.ProjectId;
                model.StatusList = new List<int> { 1,2,3};
                //查询
                var data = it_AgreeBLL.Search(model, orders, parament.rows, parament.page);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            return View();   


        }
        /// <summary>
        /// 审批中的协议
        /// </summary>
        /// <returns></returns>
        public ActionResult ApporvalsQuotation()
        { 
            string projectId = Request["projectId"]; 
            ViewBag.projectId = projectId; 
            return View();
        }
       
        /// <summary>
        /// 项目审批
        /// </summary>
        /// <param name="parament"></param>
        /// <returns></returns>
        [HttpPost]
        public ContentResult ApporvalsAction(T_AgreeModel parament)
        {
            int i = 0;
            string result = "Error";

            try
            {

                switch (parament.Action)
                {
                    case "Apporvals":
                        i = it_AgreeBLL.ApporvalsProject(parament);
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

        #region 项目协议
        public ActionResult AgreementIndex()
        {
            return View();
        }
        /// <summary>
        /// 协议签署，确认等操作
        /// </summary>
        /// <param name="parament"></param>
        /// <returns></returns>
        [HttpPost]
        public ContentResult ProjectAgreeAction(T_AgreeModel parament)
        {
            int i = 0;
            string result = "Error";

            try
            {

                switch (parament.Action)
                {
                    //协议签署
                    case "Agree":
                        i = it_AgreeBLL.AgreeProject(parament);
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

        #region 已完成项目
        public ActionResult DoneIndex()
        {
            return View();
        }
        /// <summary>
        /// 查询   状态5
        /// </summary>
        /// <returns></returns>
        public ActionResult DoneSearch(ProjectModel parament)
        {
            T_ProjectModel model = new T_ProjectModel();
            Dictionary<string, string> orders = new Dictionary<string, string>(); //排序
            string method = Request.HttpMethod;
            if (method.Equals("POST"))
            {
                //排序
                if (!string.IsNullOrEmpty(parament.sort)) ;
                orders.Add(parament.sort, parament.order);
                //查询条件 
                model.StatusList = new List<int>() {5 };
                //查询
                var data = it_ProjectBLL.Search(model, orders, parament.rows, parament.page);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            return View();   


        }
        #endregion

        #region 作废的项目
        public ActionResult FailedIndex()
        {
            return View();
        }
        /// <summary>
        /// 查询   状态10
        /// </summary>
        /// <returns></returns>
        public ActionResult FailedSearch(ProjectModel parament)
        {
            T_ProjectModel model = new T_ProjectModel();
            Dictionary<string, string> orders = new Dictionary<string, string>(); //排序
            string method = Request.HttpMethod;
            if (method.Equals("POST"))
            {
                //排序
                if (!string.IsNullOrEmpty(parament.sort)) ;
                orders.Add(parament.sort, parament.order);
                //查询条件 
                model.StatusList = new List<int>() { 10 };
                //查询
                var data = it_ProjectBLL.Search(model, orders, parament.rows, parament.page);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            return View();  
        }
        #endregion

    }
}