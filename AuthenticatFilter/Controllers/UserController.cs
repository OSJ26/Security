using AuthenticatFilter.Filter;
using AuthenticatFilter.Models;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;
using Authorization = AuthenticatFilter.Filter.Authorization;

namespace AuthenticatFilter.Controllers
{
    [RoleBaseAuthenticate]
    public class UserController : ApiController
    {
        [Authorization(Roles = "u")]
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
