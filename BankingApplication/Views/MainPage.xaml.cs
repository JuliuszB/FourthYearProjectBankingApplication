using BankingApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BankingApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : TabbedPage
    {
        Person sessionUser = new Person();
        public MainPage(Person fetchedUser)
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            sessionUser = fetchedUser;
            nameLabel.Text = fetchedUser.fName;
        }
        private void Button_Clicked_AddAccount(object sender, EventArgs e)
        {
            BankAccount accountToAdd = new BankAccount();
            accountToAdd.accountName = AccName.Text ;
            accountToAdd.accountNumber = AccNum.Text ;
            accountToAdd.accountOwner = sessionUser.phoneNo;
            accountToAdd.IBAN = iban.Text;
            accountToAdd.balance = 0.0;
            BankAccount.RunPost(accountToAdd);
        }
        private void Button_Clicked_TransferFunds(object sender, EventArgs e)
        {
            
        }
    }
}