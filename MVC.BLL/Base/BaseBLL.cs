using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.DAL;
namespace MVC.BLL
{
   public abstract partial class BaseBLL<T>
        where T :class,new()
    {
        /// <summary>
        /// 由基类指定是哪个BLL用他
        /// </summary>
        /// <returns></returns>
        public BaseDAL<T> dal;   

        /// <summary>
        /// 定义一个抽象方法来获得对象
        /// </summary>
        /// <returns></returns>
        public abstract BaseDAL<T> GetDAL();  
        public BaseBLL()
        {
            dal = GetDAL(); //这里就得到了要操作的对象
        } 
        public T GetById(int id)
        {
            return dal.GetById(id);
        }

        public int Add(T t)
        {
            return dal.Add(t);
        }
        public int Edit(T t)
        {
            return dal.Edit(t);
        }
        
        public int Delete(int id)
        {
            return dal.Delete(id);

        } 
        public int Delete(T t)
        {
            return dal.Delete(t);
        }


    }

}
