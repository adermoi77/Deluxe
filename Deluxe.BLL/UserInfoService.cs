/**
* 命名空间: Deluxe.BLL
*
* 功 能： N/A
* 类 名： UserInfoService
*
* Ver    变更日期                               负责人 
* ───────────────────────────────────
* V0.01 2017/6/30 星期五 20:50:26 Lueng 
*
* Copyright (c) 2015 Lir Corporation. All rights reserved.
*/
using Deluxe.Models.UserInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deluxe.IDAL;

namespace Deluxe.BLL
{
    public class UserInfoService : BaseService<UserInfos>,IUserInfoDal
    {
        public override void SetCurrentDal()
        {
            CurrentDal =this.DbSessionService.UserInfoDal;
        }
    }
}
