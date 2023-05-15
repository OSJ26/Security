using BasicAuthentication.DbOperation;
using BasicAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;

namespace BasicAuthentication.Bl
{
    public class BlUser
    {
        readonly ResponseModel objResponse = new ResponseModel();
        readonly DbUser objDbUser = new DbUser();

        public ResponseModel blUser()
        { 
            DataTable dtUser = objDbUser.getUserDetails();
            if (dtUser.Rows.Count > 0)
            { 
                objResponse.status = 200;
                objResponse.response = dtUser;
                return objResponse;
            }
            else
            {
                objResponse.status = 403;
                objResponse.errorMessage = "Something went wrong please check";
                return objResponse;
            }

        }

        public ResponseModel blUserById(int id)
        {
            DataTable dtUser = objDbUser.getUserById(id);
            if (dtUser.Rows.Count > 0)
            {
                objResponse.status = 200;
                objResponse.response = dtUser;
                return objResponse;
            }
            else
            {
                objResponse.status = 403;
                objResponse.errorMessage = "Something went wrong please check";
                return objResponse;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public ResponseModel Authenticate(string Email, string password)
        {
            DataTable dtAuthenticat = objDbUser.AuthenticateUser(Email, password);

            if (dtAuthenticat.Rows.Count > 0)
            {
                objResponse.status = 200;
                objResponse.response = dtAuthenticat;
                return objResponse;
            }
            else 
            {
                objResponse.status = 401;
                objResponse.errorMessage = "You are not allowed to access this resource";
                return objResponse;
            }
        }
    }
}