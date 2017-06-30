using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Deluxe.IDAL;
using IService;

namespace Deluxe.IBLL
{
    public interface IBaseService<T> where T : class, new()
    {
        IDbSession DbSessionService { get; }
        IBaseDal<T> CurrentDal { get; set; }
        /// <summary>
        /// 查询接口
        /// </summary>
        /// <param name="wherelambda"></param>
        /// <returns></returns>
        IQueryable<T> LoadEntities(Expression<Func<T, bool>> wherelambda);
        /// <summary>
        /// 分页接口
        /// </summary>
        /// <typeparam name="s"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalCount"></param>
        /// <param name="whereLamabda"></param>
        /// <param name="whereOrderByLambda"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        IQueryable<T> LoadPagesEntities<s>(int pageIndex, int pageSize, out int totalCount,
            Expression<Func<T, bool>> whereLamabda,
            Expression<Func<T, s>> whereOrderByLambda, bool isAsc);
        /// <summary>
        /// 删除方法
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool DeleteEntities(T entity);
        /// <summary>
        /// 更新方法
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool EditEntities(T entity);
        /// <summary>
        /// 添加方法
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T AddEntities(T entity);
    }
}
