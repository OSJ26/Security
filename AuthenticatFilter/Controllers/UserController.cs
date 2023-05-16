using AuthenticatFilter.Filter;
using AuthenticatFilter.Models;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AuthenticatFilter.Controllers
{
    public class UserController : ApiController
    {
        [Filter.Authorization(Roles = "a")]
        [HttpGet]
        public IHttpActionResult GetUser()
        {
            var dbFactory = new OrmLiteConnectionFactory("server = localhost; database = tnt_db; uid = om; password = om@123",MySqlDialect.Provider);

            using(var db = dbFactory.Open())
            {
                var user = db.Select<User>();
                return Ok(user);
            }
        }
    }
}
