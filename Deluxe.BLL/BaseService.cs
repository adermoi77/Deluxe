/**
* 命名空间: Deluxe.BLL
*
* 功 能： N/A
* 类 名： BaseService
*
* Ver    变更日期                               负责人 
* ───────────────────────────────────
* V0.01 2017/6/30 星期五 20:51:17 Lueng 
*
* Copyright (c) 2015 Lir Corporation. All rights reserved.
*/
using IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Deluxe.DALFactory;
using Deluxe.IDAL;

namespace Deluxe.BLL
{
    public abstract class BaseService<T> where T : class, new()
    {
        public IDbSession DbSessionService => DbSessionFactory.CreateDbSession();

        public abstract void SetCurrentDal();

        protected BaseService()
        {
            // 在创建BLL对象的时候会调用构造函数，然后SetCurrentDal是抽象方法，所以会去找实现，在子类中用的是 父类的DbSessionService点出来的数据操作对象Dal
            // ReSharper disable once VirtualMemberCallInConstructor
            SetCurrentDal();
        }

        public IBaseDal<T> CurrentDal { get; set; }

        /// <summary>
        /// 查询方法
        /// </summary>
        /// <param name="wherelambda"></param>
        /// <returns></returns>
        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> wherelambda)
        {
            return CurrentDal.LoadEntities(wherelambda);
        }

        /// <summary>
        /// 分页方法
        /// </summary>
        /// <typeparam name="s"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalCount"></param>
        /// <param name="whereLamabda"></param>
        /// <param name="whereOrderByLambda"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        public IQueryable<T> LoadPagesEntities<s>(int pageIndex, int pageSize, out int totalCount,
            Expression<Func<T, bool>> whereLamabda,
            Expression<Func<T, s>> whereOrderByLambda, bool isAsc)
        {
            return CurrentDal.LoadPagesEntities<s>(pageIndex, pageSize, out totalCount, whereLamabda,
                whereOrderByLambda, isAsc);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool DeleteEntities(T entity)
        {
            CurrentDal.DeleteEntities(entity);
            return DbSessionService.Save();
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool EditEntities(T entity)
        {
            CurrentDal.EditEntities(entity);
            return DbSessionService.Save();
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T AddEntities(T entity)
        {
            CurrentDal.AddEntities(entity);
            DbSessionService.Save();
            return entity;

        }
    }
}
