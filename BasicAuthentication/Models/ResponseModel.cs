using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicAuthentication.Models
{
    public class ResponseModel
    {
        /// <summary>
        /// store the status code
        /// </summary>
        public int status { get; set; }

        /// <summary>
        /// Store the Error Message
        /// </summary>
        public string errorMessage { get; set; }

        /// <summary>
        /// store the other Response Model
        /// </summary>
        public object response { get; set; }
    }
}