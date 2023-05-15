using BasicAuthentication.Models;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Web.Http;

namespace BasicAuthentication.DbOperation
{
    public class DbUser
    {
        MySqlConnection objConnection = new MySqlConnection(ConfigurationManager.ConnectionStrings["TntConnection"].ConnectionString);
        public DataTable getUserDetails()
        {
        

            try
            {
                objConnection.Open();
                MySqlCommand objCommand = new MySqlCommand
                    (
                        @"SELECT 
                            `user`.`id`,
                            `user`.`name`,
                            `user`.`email`,
                            `user`.`city`,
                            `user`.`pwd`,
                            `user`.`role`,
                            `user`.`mobNum`
                        FROM 
                            `tnt_db`.`user`"
                       , objConnection
                    );


                var reader = objCommand.ExecuteReader();
                DataTable dtUser = new DataTable();
                dtUser.Load(reader);
                objConnection.Close();
                return dtUser;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            { 
                objConnection.Close();
            }
        }

        public DataTable getUserById([FromUri] int id) 
        {
            
            try
            {
                if(objConnection.State != ConnectionState.Open)
                {
                    objConnection.Open();

                }
                MySqlCommand objCommand = new MySqlCommand
                    (
                        $@"SELECT 
                            `user`.`id`,
                            `user`.`name`,
                            `user`.`email`,
                            `user`.`city`,
                            `user`.`pwd`,
                            `user`.`role`,
                            `user`.`mobNum`
                        FROM 
                            `tnt_db`.`user`
                        where
                            `user`.`id` = {id}
                        "
                       , objConnection
                    );

               
                var reader = objCommand.ExecuteReader();
                DataTable dtUser = new DataTable();
                dtUser.Load(reader);
                return dtUser;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
        }

        public DataTable AuthenticateUser(string Email, string password)
        { 
            try 
            {
                if (objConnection.State != ConnectionState.Open)
                {
                    objConnection.Open();
                }
                MySqlCommand objCommand = new MySqlCommand
                    (
                        $@"
                        select 
                            `user`.`id`,
                            `user`.`name`,
                            `user`.`email`,
                            `user`.`city`,
                            `user`.`pwd`,
                            `user`.`role`,
                            `user`.`mobNum`
                        FROM 
                            `tnt_db`.`user`
                        where 
                            `user`.`email` = {Email} and `user`.`pwd`= {password} 
                        "
                        ,objConnection
                    );
                var reader = objCommand.ExecuteReader();
                DataTable dtUser = new DataTable();
                dtUser.Load(reader);
                return dtUser;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
        }
    }
}