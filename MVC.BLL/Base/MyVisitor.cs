using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace MVC.BLL
{
    /// <summary>
    /// 该类是将一个对象的lambda 装换成另外一个对象的lambda
    /// </summary>
    /// <typeparam name="SourceT">对象源</typeparam>
    /// <typeparam name="DescT">装换成的对象</typeparam>
    public class MyVisitor<SourceT, DescT> : ExpressionVisitor
    {
        private readonly ParameterExpression DescTParameter = Expression.Parameter(typeof(DescT), "p");
        private readonly ParameterExpression SourceTParameter = Expression.Parameter(typeof(SourceT), "c"); 
        protected override Expression VisitParameter(ParameterExpression node)
        {
            if (node.Type == typeof(SourceT))
            {
                return DescTParameter;
            }
            return base.VisitParameter(node);
        }
     
        protected override Expression VisitMember(MemberExpression node)
        {
            if (node.Member.ReflectedType == typeof(SourceT))
            {
                var idExpression = Expression.Property(DescTParameter, node.Member.Name);
                return idExpression;
            }
            return base.VisitMember(node);
        }
        /// <summary>
        /// 转换表达式树
        /// </summary>
        /// <param name="expression">表达式</param>
        /// <returns></returns>
        public Expression<Func<DescT, bool>> Modify(Expression<Func<SourceT, bool>> expression)
        {
            //var result = this.Visit(expression.Body);
            //return Expression.Lambda<Func<DescT, bool>>(result, DescTParameter);

            Expression<Func<DescT, bool>> result = null;
            if(expression!=null)
            {
                var newFunc = this.Visit(expression.Body);
                result = Expression.Lambda<Func<DescT, bool>>(newFunc, DescTParameter);
            }
            return result;
        }
        /// <summary>
        /// 装换表达式树List 
        /// </summary>
        /// <param name="expressionList">表达式集合</param>
        /// <returns></returns> 
        public Expression<Func<DescT, bool>> Modify(List<Expression<Func<SourceT, bool>>> expressionList)
        {
            Expression<Func<SourceT, bool>> newExpression = null; 
            Expression left = Expression.Constant(1);
            BinaryExpression query =null;
            Expression<Func<DescT, bool>> result = null;
            foreach (var expression in expressionList)
            { 
                if(query==null)
                {
                   query = Expression.Equal(left, left);  //构建一个 1==1的开头
                }
                query = Expression.And(query, expression.Body);
            }
            if (query!=null)
            {
                newExpression = Expression.Lambda<Func<SourceT, bool>>(query, SourceTParameter);
                var newFunc = this.Visit(newExpression.Body);
                result = Expression.Lambda<Func<DescT, bool>>(newFunc, DescTParameter);
            }
               
            return result;
        }

    }
}
