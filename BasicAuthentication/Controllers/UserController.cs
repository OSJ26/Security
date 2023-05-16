using BasicAuthentication.Bl;
using BasicAuthentication.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BasicAuthentication.Controllers
{
    /*[AuthenticFilter]*/
    public class UserController : ApiController
    {
        readonly BlUser objBlUser = new BlUser();

        /// <summary>
        /// get user details from bl
        /// </summary>
        /// <returns>returns HttpResponseMessage</returns>
        [HttpGet]
        [Route("getUser")]
        public  HttpResponseMessage getUser()
        {
            if(objBlUser.blUser().status == 200) 
            { 
                return Request.CreateResponse(HttpStatusCode.OK,objBlUser.blUser().response);
            }
            return Request.CreateErrorResponse(HttpStatusCode.Forbidden, objBlUser.blUser().errorMessage);
        }

        /// <summary>
        /// get user details from bl by id
        /// </summary>
        /// <returns>returns HttpResponseMessage</returns>
        [HttpGet]
        [Route("getUserById/{id}")]
        public HttpResponseMessage getUserById(int id)
        {
            if (objBlUser.blUserById(id).status == 200)
            {
                return Request.CreateResponse(HttpStatusCode.OK, objBlUser.blUserById(id).response);
            }
            return Request.CreateErrorResponse(HttpStatusCode.Forbidden, objBlUser.blUserById(id).errorMessage);
        }
/*
        [HttpGet]
        [Route("api/authenticate/verifyUser")]
        public IHttpActionResult verifyUser([FromUri] string userEmail, [FromUri] string password)
        {
            return Ok(objBlUser.blAuthenticate(userEmail, password));
        }*/
        
    }
}
