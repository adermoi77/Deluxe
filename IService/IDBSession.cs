using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using Deluxe.IDAL;

namespace IService
{
  public  interface IDbSession
    {
        DbContext DeluexDb { get; }
        IUserInfoDal UserInfoDal { get; set; }
        bool Save();
    }
}
