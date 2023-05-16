using AuthenticatFilter.Authenticator;
using ServiceStack.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using static ServiceStack.OrmLite.Dapper.SqlMapper;

namespace AuthenticatFilter.Filter
{
    public class RoleBaseAuthenticate : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers == null)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(System.Net.HttpStatusCode.Unauthorized, "Login Failed");
            }
            else
            {
                string authenticateToken = actionContext.Request.Headers.Authorization.Parameter;

                string decreptedToken = Encoding.UTF8.GetString(Convert.FromBase64String(authenticateToken));

                string[] usernamepassword = decreptedToken.Split(':');

                string username = usernamepassword[0];
                string password = usernamepassword[1];

                if (ValidateUser.Login(username, password))
                {
                    var userDetails = ValidateUser.GetData(username, password);
                    var identity = new GenericIdentity(username);
                    identity.AddClaim(new Claim(ClaimTypes.Name, userDetails.Name));
                    identity.AddClaim(new Claim(ClaimTypes.Email, userDetails.Email));
                    identity.AddClaim(new Claim("Id", Convert.ToString(userDetails.Id)));

                    IPrincipal principal = new GenericPrincipal(identity, userDetails.role.Split(','));

                    Thread.CurrentPrincipal = principal;
                    if (HttpContext.Current != null)
                    {
                        HttpContext.Current.User = principal;
                    }
                    else
                    {
                        actionContext.Response = actionContext.Request.CreateErrorResponse(System.Net.HttpStatusCode.Unauthorized, "Authorization Denied");
                    }
                }
                else
                { 
                    actionContext.Response = actionContext.Request.CreateErrorResponse(System.Net.HttpStatusCode.Unauthorized, "Invalid Details");
                }

            }
        }
    }
}