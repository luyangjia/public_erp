using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.Models;
using System.Linq.Expressions;
namespace MVC.BLL
{
    public interface IT_AgreeListBLL : BaseInterface<T_AgreeListModel>
    {
        
        /// <summary>
        /// 增加数据集
        /// </summary>
        /// <returns></returns>
        int AddDataList(List<T_AgreeListModel> model);
        /// <summary>
        /// 修改数据集
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int EditDataList(List<T_AgreeListModel> model);
        /// <summary>
        /// 删除数据集
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int DeleteDataList(List<T_AgreeListModel> model);
       
    }
}
