using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace ProjectAPI
{
    public class BankAccount
    {
        public int Id { get; set; }
        public string accountOwner { get; set; }
        public string accountName { get; set; }
        public string accountNumber { get; set; }
        public double balance { get; set; }
        public string IBAN { get; set; }
    }
}
