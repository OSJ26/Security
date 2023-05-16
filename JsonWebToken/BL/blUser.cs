using JsonWebToken.DBContext;
using JsonWebToken.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JsonWebToken.BL
{
    public class blUser
    {
        MyDbInfo objInfo = new MyDbInfo();
        Response objResponse = new Response();
        public Response blData()
        { 
            objResponse.DataModel =  objInfo.getData();
            if (objResponse.DataModel == null)
            {

                objResponse.IsError = true;
                objResponse.Message = "Check, something gonna wrong";
            }
            else
            {
                objResponse.IsError = false;
                objResponse.Message = "Data Found Enjoy";
            }
            return objResponse;
        }
    }
}