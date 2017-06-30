 
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Text;
using Deluxe.Models;

namespace Deluxe.DAL
{
    public class DbContextFactory
    {
        public static DbContext CreateDbContext()
        {
            DeluxeContext dbContext = (DeluxeContext) CallContext.GetData("dbcontext");
            if (dbContext == null)
            {
                dbContext = new DeluxeContext();
                CallContext.SetData("dbcontext", dbContext);
            }
            return dbContext;
        }
    }
}
