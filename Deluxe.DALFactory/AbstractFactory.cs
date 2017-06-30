/**
* 命名空间: Deluxe.DALFactory
*
* 功 能： N/A
* 类 名： AbstractFactory
*
* Ver    变更日期                               负责人 
* ───────────────────────────────────
* V0.01 2017/6/30 星期五 20:14:07 Lueng 
*
* Copyright (c) 2015 Lir Corporation. All rights reserved.
*/
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Deluxe.IDAL;

namespace Deluxe.DALFactory
{
    /// <summary>
    /// 抽象工厂：通过反射的形式来创建数据操作类的实例
    /// </summary>
    public class AbstractFactory
    {
        private static readonly string AssemblyPath = ConfigurationManager.AppSettings["AssemblyPath"];
        private static readonly string NameSpace = ConfigurationManager.AppSettings["NameSpace"];

        /// <summary>
        /// 创建UserInfo的实例
        /// </summary>
        /// <returns></returns>
        public static IUserInfoDal CreateUserInfoDal()
        {
            string fullClassName = NameSpace + ".UserInfoDal";
            return CreateInstance(fullClassName) as IUserInfoDal;//注意转成的是接口，不能是具体的数据操作类，要不然又耦合了
        }
        /// <summary>
        /// 通过反射创建类的实例
        /// </summary>
        /// <param name="fullClassName"></param>
        /// <returns></returns>
        private static object CreateInstance(string fullClassName)
        {
          var assembly=  Assembly.Load("AssemblyPath");
            return assembly.CreateInstance(fullClassName);

        }
    }
}
