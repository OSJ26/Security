using JsonWebToken.BL;
using JsonWebToken.DBContext;
using JsonWebToken.JwtService;
using JsonWebToken.Models;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace JsonWebToken.Controllers
{
    public class TokenController : ApiController
    {
        blUser objUser = new blUser();
        MyDbInfo objInfo = new MyDbInfo();

        [HttpGet]
        [RouteAttribute("getDetails")]
        public HttpResponseMessage getDetails()
        {
            if (objUser.blData().IsError == true)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, objUser.blData().Message);
            }
            return Request.CreateResponse(HttpStatusCode.OK,objUser.blData().DataModel);
        }

        /// <summary>
        /// Verify user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>Status of reuquest</returns>
        [AllowAnonymous]
        [Route("validate/VerifyUser")]
        [HttpPost]
        public IHttpActionResult verifyUser([FromBody] string username) 
        {
            return Ok(objInfo.Login(username));
        }

    }
}
