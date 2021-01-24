using System;

namespace BankingApplication.Models
{
   
    public class User
    {
        public Guid Guid { get; set; }
        public string fName { get; set; }
        public string sName { get; set; }
        public string phoneNo { get; set; }
        public string password { get; set; }

    }
}