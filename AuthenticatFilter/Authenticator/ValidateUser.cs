using AuthenticatFilter.Controllers;
using ServiceStack.OrmLite;
using AuthenticatFilter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using User = AuthenticatFilter.Models.User;

namespace AuthenticatFilter.Authenticator
{
    public class ValidateUser
    {
        /// <summary>
        /// Check the email adn password is matched or not
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns> return true if data match else false</returns>
        public static bool Login(string email, string password)
        {
            var dbFactory = new OrmLiteConnectionFactory("server = localhost; database = tnt_db; uid = om; password = om@123",MySqlDialect.Provider);

            try 
            {
                using (var db = dbFactory.Open())
                {
                    return db.Select<User>().Any<User>(user => user.Email.Equals(email) && user.Password.Equals(password));
                    
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Get the data from  the database
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns>return record based on email and password</returns>
        public static User GetData(string email, string password)
        {
            var dbFactory = new OrmLiteConnectionFactory("server = localhost; database = tnt_db; uid = om; password = om@123", MySqlDialect.Provider);

            try 
            {
                using (var db = dbFactory.Open())
                {
                    return db.Select<User>().FirstOrDefault<User>(user => user.Email.Equals(email) && user.Password.Equals(password));
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}