using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text; 

namespace Deluxe.DAL
{
    public class BaseDal<T> where T : class, new()
    {
        private readonly DbContext _deluexDb = DbContextFactory.CreateDbContext();
        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> wherelambda)
        {
            //简化写法   return deluexDb.UserInfos.Where(wherelambda);
            return _deluexDb.Set<T>().Where<T>(wherelambda);
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="s"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalCount"></param>
        /// <param name="whereLamabda"></param>
        /// <param name="whereOrderByLambda"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        public IQueryable<T> LoadPagesEntities<s>(int pageIndex, int pageSize, out int totalCount, Expression<Func<T, bool>> whereLamabda,
            Expression<Func<T, s>> whereOrderByLambda, bool isAsc)
        {
            var temp = _deluexDb.Set<T>().Where<T>(whereLamabda);
            totalCount = temp.Count();
            if (isAsc)
            {
                temp = temp.OrderBy<T, s>(whereOrderByLambda).Skip<T>((pageIndex - 1) * pageSize)
                    .Take<T>(pageSize);
            }
            else
            {
                temp = temp.OrderByDescending<T, s>(whereOrderByLambda).Skip<T>((pageIndex - 1) * pageSize)
                    .Take<T>(pageSize);
            }
            return temp;
        }
        
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool DeleteEntities(T entity)
        {
            _deluexDb.Entry<T>(entity).State = EntityState.Deleted;
            return true;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool EditEntities(T entity)
        {
            _deluexDb.Entry<T>(entity).State = EntityState.Modified;
            return true;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T AddEntities(T entity)
        {
            _deluexDb.Set<T>().Add(entity); 
            return entity;
        }
    }
}
