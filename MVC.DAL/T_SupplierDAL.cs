using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace MVC.DAL
{
    public partial class T_SupplierDAL : BaseDAL<T_Supplier>
    {
        /// <summary>
        /// 先实现这两个抽象方法
        /// </summary>
        /// <returns></returns>
        //public override Expression<Func<t_user, int>> GetKeyID()
        //{
        //    return u => u.id;
        //}
        public override Expression<Func<T_Supplier, bool>> GetKeyByuId(int id)
        {
            return u => u.Id == id;
        }

    }
}
