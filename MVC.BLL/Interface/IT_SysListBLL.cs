using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.Models;
using System.Linq.Expressions;
namespace MVC.BLL
{
    public interface IT_SysListBLL : BaseInterface<T_SysListModel>
    { 
     
        /// <summary>
        /// 获取树节点
        /// </summary>
        /// <param name="SysId"></param>
        /// <param name="Type">text 表示 ID也赋值name 否则还是ID</param>
        /// <returns></returns>
        List<T_TreeSysListModel> Tree(int SysId,string Type="id");
        /// <summary>
        /// 下拉框树
        /// </summary>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        List<T_TreeSysListModel> TreeCombox(int SysId);
        /// <summary>
        /// 根据节点获得顶级的节点
        /// </summary>
        /// <param name="Id">当前节点</param>
        ///  <param name="SysId">所属类型ID</param>
        /// <returns></returns>
        List<T_ParentSysListModel> ParentList(int Id);
        // <summary>
        /// 获得该节点下所有子节点
        /// </summary>
        /// <param name="SysId">模块ID</param>
        ///  <param name="Id"></param>
        /// <returns></returns>
        List<int> GetChildren(int SysId, int Id);
    }
}
