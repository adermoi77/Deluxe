using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using Deluxe.DAL;
using Deluxe.IDAL;
using IService;

namespace Deluxe.DALFactory
{
    public class DbSession:IDbSession
    {
        private IUserInfoDal _userInfoDal;
        public DbContext DeluexDb => DbContextFactory.CreateDbContext();

        public IUserInfoDal UserInfoDal
        {
            get => _userInfoDal ?? (_userInfoDal = new UserInfoDal());
            set => _userInfoDal = value;
        }

        /// <summary>
        /// 一个业务可能需要多次访问数据库来完成操作，这个方法统一访问
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            return DeluexDb.SaveChanges() > 0;
        }
    }
}
