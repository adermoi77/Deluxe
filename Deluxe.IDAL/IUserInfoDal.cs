using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Deluxe.Models.UserInfo;

namespace Deluxe.IDAL
{
    public interface IUserInfoDal:IBaseDal<UserInfos>
    {
        //定义针对UserInfos特有的方法
    }
}
