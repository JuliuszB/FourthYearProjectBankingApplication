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

        public void withdraw(BankAccount toCopy, double amt)
        {
            this.accountOwner = toCopy.accountOwner;
            this.accountName = toCopy.accountName;
            this.accountNumber = toCopy.accountNumber;
            this.balance = toCopy.balance - amt;
            this.IBAN = toCopy.IBAN;
        }
        public void deposit(BankAccount toCopy, double amt)
        {
            this.accountOwner = toCopy.accountOwner;
            this.accountName = toCopy.accountName;
            this.accountNumber = toCopy.accountNumber;
            this.balance = toCopy.balance + amt;
            this.IBAN = toCopy.IBAN;
        }


    }
}
