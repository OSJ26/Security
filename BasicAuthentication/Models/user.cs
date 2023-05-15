using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicAuthentication.Models
{
    public class user
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string role { get; set; }
        public string city { get; set; }

/*        #region Private members
        private int _id;
        private string _name;
        private string _email;
        private string _password;
        private string _city;
        private string _role;
        private string _phone;
        #endregion

        #region Public getter-setter
        public int Id { 
            get 
            { 
                return _id; 
            } 
            set 
            { 
                _id = value; 
            } 
        }

        public string name 
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public string email
        { 
            get
            { 
                return _email;
            }
            set
            {
                _email = value;
            }
        }

        public string password
        { 
            get
            { 
                return _password;
            }
            set
            {
                _password = value;
            }
        }

        public string city
        { 
            get
            { 
                return _city; 
            }
            set
            {
                _city = value;
            }
        }

        public string role
        { 
            get 
            { 
                return _role; 
            }
            set
            {
                _role = value;
            }
        }

        public string phone
        { 
            get 
            { 
                return _phone;
            }
            set
            {
                _phone = value;
            }
        }
        #endregion*/


    }
}