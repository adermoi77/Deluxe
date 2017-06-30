using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 

namespace Deluxe.IDAL
{
    public interface IBaseDal<T> where T : class, new()
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="wherelambda">lambda表达式</param>
        /// <returns></returns>
        IQueryable<T> LoadEntities(System.Linq.Expressions.Expression<Func<T, bool>> wherelambda);

        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="s">排序类型</typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalCount"></param>
        /// <param name="whereLamabda"></param>
        /// <param name="whereOrderByLambda"></param>
        /// <param name="isAsc">升序或降序</param>
        /// <returns></returns>
        IQueryable<T> LoadPagesEntities<s>(int pageIndex, int pageSize, out int totalCount,
            System.Linq.Expressions.Expression<Func<T, bool>> whereLamabda,
            System.Linq.Expressions.Expression<Func<T, s>> whereOrderByLambda, bool isAsc);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool DeleteEntities(T entity);

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool EditEntities(T entity);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T AddEntities(T entity);
    }
}
