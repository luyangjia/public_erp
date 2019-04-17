using System;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Collections.Generic;
using MVC.Helper.log;
using System.Reflection;


namespace MVC.DAL
{
    /// <summary>
    /// 这里定义一个基类，是个泛型，并给约束，要求是引用的
    /// 做到面向抽象
    /// </summary>
    /// <typeparam name="T">泛型</typeparam>
    public abstract partial class BaseDAL<T> : BaseLog<T>
       where T : class,new()
    {
        //  protected  DbContext dbContext = new HgmasDBEntities();
        EmpContext dbContext = new EmpContext(); 
        /// <summary>  
        /// 新增  
        /// </summary>  
        /// <param name="model">实体</param>  
        /// <returns>返回受影响行数</returns>  
        public DbSet<T> dbSet()
        {
            DbSet<T> iret = null;
            Logger("向" + typeof(T).Name + "，dbContext.Set查询数据", () =>
            {
                iret = dbContext.Set<T>();
            });
            return iret;

            //dbContext.Set<T>().Add(model);
            //return dbContext.SaveChanges();
        }
        /// <summary>  
        /// 新增  
        /// </summary>  
        /// <param name="model">实体</param>  
        /// <returns>返回受影响行数</returns>  
        public int Add(T model)
        {
            int iret = -1; 
            Logger("向" + typeof(T).Name + "增加数据", () =>
            {
                dbContext.Set<T>().Add(model);
                iret = dbContext.SaveChanges();
            });
            return iret;

            //dbContext.Set<T>().Add(model);
            //return dbContext.SaveChanges();
        }
        /// <summary>  
        /// 修改  
        /// </summary>  
        /// <param name="model">实体</param>  
        /// <returns>返回受影响行数</returns>  
        public int Edit(T model)
        {
            int iret = -1;
            Logger("修改表：" + typeof(T).Name, () =>
            {
                dbContext.Set<T>().Attach(model);
                dbContext.Entry(model).State = EntityState.Modified;
                iret = dbContext.SaveChanges();
                //var entry=dbContext.Entry(model);
                //entry.State = EntityState.Modified; 
                //  iret = dbContext.SaveChanges();
            });
            return iret;
        }
        /// <summary>  
        /// 删除，根据主键  
        /// </summary>  
        /// <param name="id">主键</param>  
        /// <returns>返回受影响行数</returns>  
        public int Delete(int id)
        {
            int iret = -1;
            Logger("删除表：" + typeof(T).Name + ",ID:" + id, () =>
            {
                //dbContext.Set<T>().Remove(GetById(id)); 
                //iret = dbContext.SaveChanges();

                //dbContext.Set<T>().Attach(GetById(id));
                //dbContext.Entry(GetById(id)).State = EntityState.Deleted;
                //iret = dbContext.SaveChanges();

                iret = Delete(GetById(id));

            });
            return iret;

        }
        /// <summary>  
        /// 删除，根据实体 
        /// </summary>  
        /// <param name="model">实体</param>  
        /// <returns>返回受影响行数</returns>  
        public int Delete(T model)
        {
            int iret = -1;
            Logger("根据模型删除表：" + typeof(T).Name, () =>
            {
                dbContext.Set<T>().Attach(model);
                dbContext.Entry(model).State = EntityState.Deleted;
                iret = dbContext.SaveChanges();
            });
            return iret;

        }
        /// <summary>
        /// 根据条件删除
        /// </summary>
        /// <param name="LambdaWhere">删除条件</param>
        /// <returns></returns>
        public int Delete(Expression<Func<T, bool>> LambdaWhere)
        {
            int iret = -1;
            Logger("根据条件删除：" + typeof(T).Name, () =>
            {
                List<T> getmode = dbContext.Set<T>().Where(LambdaWhere).ToList();
                getmode.ForEach(u =>
                {
                    dbContext.Set<T>().Attach(u);  //先附加到EF 容器
                    dbContext.Set<T>().Remove(u); //标识为删除状态
                });
                iret = dbContext.SaveChanges();
            });
            return iret;

        }




        #region Lambda表达式的各种查询

        /// <summary>
        /// 根据ID查询返回数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        public T GetById(int id)
        {
            T iret = null;
            Logger("根据ID查询：" + typeof(T).Name + ",id:" + id, () =>
            {
                iret = dbContext.Set<T>()
               .Where(GetKeyByuId(id))
               .AsNoTracking()
               .FirstOrDefault();
            });
            return iret;
        } 
        /// <summary>
        /// 根据Lambda条件查询和排序
         /// </summary>
        /// <param name="LambdaWhere">Lambda查询条件</param>
        /// <param name="Orders">排序字典key:排序的字段,value:asc升序/desc降序</param>
         /// <returns></returns>
        public IQueryable<T> Filter(Expression<Func<T, bool>> LambdaWhere = null, Dictionary<string, string> Orders=null)
        { 
            IQueryable<T> iret = null; 
            Logger("查询：" + typeof(T).Name, () =>
            {
                if (LambdaWhere != null)
                    iret = dbContext.Set<T>().Where(LambdaWhere);
                else
                    iret = dbContext.Set<T>(); 
              //排序
                if (Orders != null)
                    iret = OrderBy(iret, Orders); 
                iret = iret.AsNoTracking();  
            });
            return iret;

        }
        /// <summary>
        /// 复杂查询
        /// </summary>
        /// <param name="Total">返回总行数</param>
        /// <param name="LambdaWhere">查询条件</param>
        /// <param name="Orders">排序字典key:排序的字段,value:asc升序/desc降序</param> 
        /// <param name="PageSize">每页行数，默认15</param>
        /// <param name="PageIndex">当前页码，默认100</param> 
        /// <returns></returns>
        public IQueryable<T> Search(out int Total, Expression<Func<T, bool>> LambdaWhere = null, Dictionary<string, string> Orders = null, int PageSize = 15, int PageIndex = 100)
        {
            int total = 0;
            IQueryable<T> iret = null; 
            Logger("查询：" + typeof(T).Name, () =>
            { 
                if (LambdaWhere != null)
                    iret = dbContext.Set<T>().Where(LambdaWhere);
                else
                    iret = dbContext.Set<T>();
                //排序
                if (Orders != null)
                    iret = OrderBy(iret, Orders);
                iret = iret.AsNoTracking();   
                total = iret.Count();//获取总数  
                iret = iret.Skip((PageIndex - 1) * PageSize).Take(PageSize);
            });
            Total = total;
            return iret;

        }
        /// 复杂查询(弃用)
        /// </summary>
        /// <param name="LambdaWhere">查询条件</param>
        /// <param name="DicOrder">排序字典key:排序的字段,value:asc升序/desc降序</param>
        /// <param name="Total">返回总行数</param>
        /// <param name="PageSize">每页行数，默认15</param>
        /// <param name="PageIndex">当前页码，默认100</param> 
        /// <returns></returns>
        public IQueryable<T> SearchList(List<Expression<Func<T, bool>>> LambdaWhere, Dictionary<string, string> DicOrder, out int Total, int PageSize = 15, int PageIndex = 100)
        {
            int total = 0;
            IQueryable<T> iret = null;
            Logger("查询：" + typeof(T).Name, () =>
            {
                iret = dbContext.Set<T>();
                if (LambdaWhere.Count() > 0)
                {
                    foreach (var expression in LambdaWhere)
                    {
                        iret = iret.Where(expression);
                    }
                }
                total = iret.Count();//获取总数  
                iret = OrderBy(iret, DicOrder);
                iret = iret.AsNoTracking().Skip((PageIndex - 1) * PageSize).Take(PageSize);
            });
            Total = total;
            return iret;

        }


        #endregion

        #region 支持SQL的操作
        /// <summary>
        /// 根据SQL 返回查询对象
        /// </summary>
        /// <typeparam name="T">查询结果对象</typeparam>
        /// <param name="sql">SQL语句</param>
        /// <param name="parms">SQL参数</param>
        /// <returns></returns>
        public virtual List<T> Query<T>(string sql, object parms = null)
        {
            return dbContext.Database.SqlQuery<T>(sql, parms).ToList();
        }

        #endregion

        /// <summary>
        /// 抽象方法的定义，继承的类要实列化
        /// 定义一个抽象方法，OrderByDescending用，抽象方法必须在抽象类中
        /// 
        /// </summary>
        /// <returns></returns>
        // public abstract Expression<Func<T, int>> GetKeyID();
        /// <summary>
        /// where 的查询结果返回的是true/false ,所以定义个返回布尔值的抽象方法
        /// </summary>
        /// <returns></returns>
        public abstract Expression<Func<T, bool>> GetKeyByuId(int id);
         /// <summary>
         /// 排序
         /// </summary>
         /// <typeparam name="T"></typeparam>
         /// <param name="source">数据集</param>
        /// <param name="dicOrder">排序字典key:排序的字段,value:asc升序/desc降序</param>
         /// <returns></returns>
        public IQueryable<T> OrderBy<T>(IQueryable<T> source, Dictionary<string, string> dicOrder) where T : class
        {
            Type type = typeof(T);
            ParameterExpression param = Expression.Parameter(type, "p");
            string methodName = "";
            string AscOrDesc = "asc";
            int n = 0;
            foreach (var order in dicOrder)
            {
                AscOrDesc = order.Value.ToUpper();
                PropertyInfo property = type.GetProperty(order.Key);
                if (property == null)
                    throw new ArgumentException("propertyName", "Not Exist");
                Expression propertyAccessExpression = Expression.MakeMemberAccess(param, property);
                LambdaExpression orderByExpression = Expression.Lambda(propertyAccessExpression, param);
               if(n==0)
                   methodName = AscOrDesc=="ASC" ? "OrderBy" : "OrderByDescending";
               else
                   methodName = AscOrDesc == "ASC" ? "ThenBy" : "ThenByDescending";
               MethodCallExpression resultExp = Expression.Call(typeof(Queryable), methodName, new Type[] { type, property.PropertyType }, source.Expression, Expression.Quote(orderByExpression));
               source = source.Provider.CreateQuery<T>(resultExp);
               n = n = 1; 
            } 
            return source;
        }
    }
}
