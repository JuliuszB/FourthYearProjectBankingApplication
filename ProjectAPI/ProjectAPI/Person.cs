using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectAPI
{
    public class Person
    {
        public int id { get; set; }
        public string fName { get; set; }
        public string sName { get; set; }
        public string phoneNo { get; set; }
        public string password { get; set; }
        public string isLoggedIn { get; set; }
        public string email { get; set; }

        public void copy(Person toCopy)
        {
            this.fName = toCopy.fName;
            this.email = toCopy.email;
            this.isLoggedIn = toCopy.isLoggedIn;
            this.sName = toCopy.sName;
            this.phoneNo = toCopy.phoneNo;
            this.password = toCopy.password;
        }
    }
}