using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace JsonWebToken.CommonMethods
{
    public class CommonMethod
    {
        public IDbConnection openConnection()
        {
            var dbFactory = new OrmLiteConnectionFactory(ConnStr.ConnectionString,MySqlDialect.Provider);
            return dbFactory.Open();
        }
    }
}