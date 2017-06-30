/**
* 命名空间: Deluxe.DALFactory
*
* 功 能： N/A
* 类 名： DBSessionFactory
*
* Ver    变更日期                               负责人 
* ───────────────────────────────────
* V0.01 2017/6/30 星期五 21:54:25 Lueng 
*
* Copyright (c) 2015 Lir Corporation. All rights reserved.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using IService;

namespace Deluxe.DALFactory
{
  public  abstract class DbSessionFactory
    {
        public static IDbSession CreateDbSession()
        {
            IDbSession dbSession =(IDbSession) CallContext.GetData("dbSession");
            if (dbSession==null)
            {
                dbSession=new DbSession();
                CallContext.SetData("dbSession",dbSession);
            }
            return dbSession;
        }
    }
}
