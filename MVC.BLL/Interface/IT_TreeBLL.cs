using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.Models;
using System.Linq.Expressions;
namespace MVC.BLL
{

    public interface IT_TreeBLL : BaseInterface<T_TreeModel>
    { 
        /// <summary>
        /// 获取菜单树
        /// </summary>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        List<T_TreeMenuModel> Tree(Dictionary<string, object> dictionary = null);
        /// <summary>
        /// 获取1，2级节点
        /// </summary>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        List<T_TreeCombo> TreeParent();
    }


}
